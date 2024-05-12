namespace AutoMoreira.Persistence.Services
{
    public class UserService : IUserService
    {
        #region Private variables

        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmailService _emailService;

        #endregion

        #region Constructors
        public UserService(
            IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IEmailService emailService
            )
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;

            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _emailService = emailService;
        }

        #endregion

        #region Public methods

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            try
            {
                List<User> users = await _userRepository
                    .GetAll()
                    .Include(x => x.Roles)
                    .OrderBy(x => x.Id).ToListAsync();

                return _mapper.Map<List<UserDTO>>(users);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetAllUsersAsyncException} {ex.Message}");
            }
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            try
            {
                User? user = await _userRepository.GetAll()
                    .Where(x => x.Id == id)
                    .Include(x => x.Roles)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                user.ThrowIfNull(() => throw new Exception(DomainResource.UserNotFoundException));

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetUserByIdAsyncException} {ex.Message}");
            }
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            try
            {
                User? user = await _userRepository
                    .GetAll()
                    .Where(x => x.Email == email)
                    .Include(x => x.Roles)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                user.ThrowIfNull(() => throw new Exception(DomainResource.UserNotFoundException));

                UserDTO userDTO = _mapper.Map<UserDTO>(user);

                return userDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetUserByEmailAsyncException} {ex.Message}");
            }
        }

        public async Task<bool> LoginUserAsync(UserLoginDTO userLoginDTO)
        {
            try
            {
                User? user = await _userManager
                   .Users
                   .SingleOrDefaultAsync(user => user.Email == userLoginDTO.Email);

                user.ThrowIfNull(() => throw new Exception(DomainResource.UserNotFoundException));

                SignInResult signInResult = await _signInManager
                    .CheckPasswordSignInAsync(user, userLoginDTO.Password, false);

                return signInResult.Succeeded;
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.LoginUserAsyncException} {ex.Message}");
            }
        }

        public async Task<UserDTO> AddUserAsync(UserDTO userDTO)
        {
            try
            {
                UserExistsAsync(userDTO.Id, userDTO.Email).Result
                    .Throw(() => throw new Exception(DomainResource.UserAlreadyExistsException))
                    .IfTrue();

                User user = new(userDTO.Email, userDTO.PhoneNumber, userDTO.FirstName, userDTO.LastName);

                user = await UpdateRoleAsync(user, userDTO);

                string password = GenerateNewPassword();

                IdentityResult identityResult = await _userManager.CreateAsync(user, password);

                identityResult.Succeeded.Throw(() => throw new Exception(DomainResource.UserNotFoundException))
                    .IfFalse();

                await _emailService.SendEmailToUserAsync($"{user.FirstName} {user.LastName}", user.Email, password);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.AddUserAsyncException} {ex.Message}");
            }
        }

        public async Task<UserDTO> UpdateUserAsync(UserDTO userDTO)
        {
            try
            {
                User? user = await _userRepository
                    .GetAll()
                    .Where(x => x.Id == userDTO.Id)
                    .Include(x => x.Roles)
                    .FirstOrDefaultAsync();

                user.ThrowIfNull(() => throw new Exception(DomainResource.UserNotFoundException));

                UserExistsAsync(user.Id, user.Email).Result
                    .Throw(() => throw new Exception(DomainResource.UserAlreadyExistsException))
                    .IfTrue();

                user.Update(userDTO.Email, userDTO.PhoneNumber, userDTO.FirstName, userDTO.LastName, userDTO.Image);

                if (user.IsDefault)
                {
                    user = await UpdateWithAdminRoleAsync(user);
                }
                else
                {
                    user = await UpdateRoleAsync(user, userDTO);
                }

                if (userDTO.Password != null)
                {
                    await UpdatePasswordAsync(user, userDTO.Password);
                }

                await _userRepository.UpdateAsync(user);

                await _emailService.SendEmailToUpdatedUserAsync($"{user.FirstName} {user.LastName}", user.Email);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.UpdateUserAsyncException} {ex.Message}");
            }
        }

        public async Task<UserDTO> UpdateUserModeAsync(int id, bool mode)
        {
            try
            {
                User? user = await _userRepository.FindByIdAsync(id);

                user.ThrowIfNull(() => throw new Exception(DomainResource.UserNotFoundException));

                user.SetDarkMode(mode);

                await _userRepository.UpdateAsync(user);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.UpdateUserModeAsyncException} {ex.Message}");
            }
        }

        public async Task<UserDTO> UpdateUserImageAsync(int id, string? image)
        {
            try
            {
                User? user = await _userRepository.FindByIdAsync(id);

                user.ThrowIfNull(() => throw new Exception(DomainResource.UserNotFoundException));

                user.SetImage(image);

                await _userRepository.UpdateAsync(user);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.UpdateUserImageAsyncException} {ex.Message}");
            }
        }

        public async Task<UserDTO> UpdateUserPasswordAsync(UserLoginDTO userLoginDTO)
        {
            try
            {
                User? user = await _userRepository
                    .GetAll()
                    .Where(x => x.Email == userLoginDTO.Email)
                    .FirstOrDefaultAsync();

                user.ThrowIfNull(() => throw new Exception(DomainResource.UserNotFoundException));

                await UpdatePasswordAsync(user, userLoginDTO.Password);

                await _emailService.SendEmailToUserUpdatePasswordAsync($"{user.FirstName} {user.LastName}", user.Email, userLoginDTO.Password);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.UpdateUserPasswordAsyncException} {ex.Message}");
            }
        }

        public async Task<UserDTO> ResetUserPasswordAsync(string email)
        {
            try
            {
                User? user = await _userRepository
                    .GetAll()
                    .Where(x => x.Email == email)
                    .FirstOrDefaultAsync();

                user.ThrowIfNull(() => throw new Exception(DomainResource.UserNotFoundException));

                var password = GenerateNewPassword();

                await UpdatePasswordAsync(user, password);

                await _emailService.SendEmailToUserResetPasswordAsync($"{user.FirstName} {user.LastName}", user.Email, password);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.ResetUserPasswordAsyncException} {ex.Message}");
            }
        }

        public async Task<List<ResponseMessageDTO>> DeleteUsersAsync(List<int> usersIds)
        {
            return await DeleteAsync(usersIds);
        }

        #endregion

        #region Private methods

        private async Task<bool> UserExistsAsync(int id, string email)
        {
            return await _userRepository
                .GetAll()
                .AnyAsync(user => user.Id != id && user.Email.Trim().ToLower() == email.Trim().ToLower());
        }

        private async Task<User> UpdateRoleAsync(User user, UserDTO userDTO)
        {
            (userDTO.Roles.Count == 0)
                .Throw(() => throw new Exception(DomainResource.RoleNotFoundException))
                .IfTrue();

            Role? role = await _roleRepository
                .FindByIdAsync(userDTO.Roles.FirstOrDefault()?.Id ?? 0);

            role.ThrowIfNull(() => throw new Exception(DomainResource.RoleNotFoundException));

            user.SetRoles(new List<Role> { role });

            return user;
        }

        private async Task<User> UpdateWithAdminRoleAsync(User user)
        {

            Role? role = await _roleRepository
                .GetAll()
                .Where(x => x.IsDefault && x.IsReadOnly)
                .FirstOrDefaultAsync();

            role.ThrowIfNull(() => throw new Exception(DomainResource.DefaultRoleNotFoundException));

            user.SetRoles(new List<Role> { role });

            return user;
        }

        private async Task UpdatePasswordAsync(User user, string password)
        {
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);

            IdentityResult identityResult = await _userManager.ResetPasswordAsync(user, token, password);

            identityResult.Succeeded
                    .Throw(() => throw new Exception(DomainResource.UpdateUserPasswordAsyncException))
                    .IfFalse();
        }

        private static string GenerateNewPassword()
        {
            Random rnd = new();
            return rnd.Next(100000, 1000000000).ToString();
        }

        private async Task<List<ResponseMessageDTO>> DeleteAsync(List<int> usersIds)
        {
            List<ResponseMessageDTO> responseMessageDTOs = new();

            foreach (int userId in usersIds)
            {
                ResponseMessageDTO responseMessageDTO = new() { Entity = new MinimumDTO() { Id = userId }, OperationSuccess = false };
                try
                {
                    User? user = await _userRepository.FindByIdAsync(userId);

                    if (user is not null)
                    {
                        responseMessageDTO.Entity.Name = user.Email;

                        if (user.IsDefault)
                        {
                            responseMessageDTO.ErrorMessage = DomainResource.DeleteDefaultUserAsyncException;
                        }
                        else
                        {
                            await _userRepository.RemoveAsync(user);
                            responseMessageDTO.OperationSuccess = true;
                        }
                    }
                    else
                    {
                        responseMessageDTO.ErrorMessage = DomainResource.UserNotFoundException;
                    }
                }

                catch (Exception)
                {
                    responseMessageDTO.ErrorMessage = DomainResource.DeleteUsersAsyncException;
                }

                responseMessageDTOs.Add(responseMessageDTO);
            }

            return responseMessageDTOs;
        }

        #endregion
    }
}
