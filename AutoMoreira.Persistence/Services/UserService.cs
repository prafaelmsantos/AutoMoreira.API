namespace AutoMoreira.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IRoleRepository _roleRepository;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, 
            IMapper mapper, IUserRepository userRepository, IEmailService emailService, 
            IRoleRepository roleRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userRepository = userRepository;
            _emailService = emailService;
            _roleRepository = roleRepository;
        }

        public async Task<bool> CheckUserPasswordAsync(UserDTO userDTO, string password)
        {
            try
            {
                User? user = await _userManager.Users.SingleOrDefaultAsync(user => user.Email == userDTO.Email);
                SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(user!, password, false);

                return signInResult.Succeeded;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar password. Erro: {ex.Message}");

            }
        }

        public async Task<UserDTO?> CreateUserAsync(UserDTO userDTO)
        {
            try
            {
                if (userDTO.Roles.Count == 0) throw new Exception("Nenhum cargo encontrado.");

                User? user = new(userDTO.Email, userDTO.PhoneNumber, userDTO.FirstName, userDTO.LastName);

                Role? role = await _roleRepository.FindByIdAsync(userDTO.Roles.FirstOrDefault()!.Id);

                if (role != null)
                {
                    user.SetRoles(new List<Role> { role });
                }

                string password = GenerateNewPassword();

                IdentityResult identityResult = await _userManager.CreateAsync(user, password);

                if (identityResult.Succeeded)
                {
                    await _emailService.SendEmailToUserAsync($"{user.FirstName} {user.LastName}", user.Email, password);
                    return _mapper.Map<UserDTO>(user);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar criar conta de utilizador!. Erro: {ex.Message}");

            }
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            User? user = await _userRepository
                .GetAll()
                .Where(x => x.Email == email)
                .Include( x=> x.Roles)
                .FirstOrDefaultAsync() ?? throw new Exception("Utilizador não encontrado.");

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            try
            {
                User? user = await _userRepository.GetAll()
                    .Where(x=> x.Id == id)
                    .Include(x => x.Roles)
                    .FirstOrDefaultAsync() ?? throw new Exception("Utilizador não encontrado.");

                return _mapper.Map<UserDTO>(user);

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar procurar utilizador por id. Erro: {ex.Message}");
            }
        }
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
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserDTO> UpdateUserAsync(UserDTO userDTO)
        {
            try
            {
                User? user = await _userRepository
                    .GetAll()
                    .Where(x => x.Id == userDTO.Id)
                    .Include( x => x.Roles)
                    .FirstOrDefaultAsync() ?? throw new Exception("Utilizador não encontrado.");
                
                user.UpdateUser(userDTO.Email, userDTO.PhoneNumber, userDTO.FirstName, userDTO.LastName, userDTO.Image);

                Role? role = await _roleRepository.FindByIdAsync(userDTO.Roles.FirstOrDefault()!.Id);

                if (role != null && !user.IsDefault)
                {
                    user.SetRoles(new List<Role> { role });
                }
                
                if (userDTO.Password != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    await _userManager.ResetPasswordAsync(user, token, userDTO.Password);
                }
                
                await _userRepository.UpdateAsync(user);

                await _emailService.SendEmailToUpdatedUserAsync($"{user.FirstName} {user.LastName}", user.Email);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar utilizador. Erro: {ex.Message}");
            }
        }

        public async Task<UserDTO> UpdateUserModeAsync(int id, bool mode)
        {
            try
            {
                User? user = await _userRepository.FindByIdAsync(id) ?? throw new Exception("Utilizador não encontrado.");
                
                user.SetDarkMode(mode);

                await _userRepository.UpdateAsync(user);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar o modo de utilizador. Erro: {ex.Message}");
            }
        }

        public async Task<UserDTO> UpdateUserImageAsync(int id, string image)
        {
            try
            {
                User? user = await _userRepository.FindByIdAsync(id) ?? throw new Exception("Utilizador não encontrado.");
                
                user.SetImage(image);

                await _userRepository.UpdateAsync(user);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar o modo de utilizador. Erro: {ex.Message}");
            }
        }

        public async Task UserResetPasswordAsync(string email)
        {
            try
            {
                User? user = await _userRepository
                    .GetAll()
                    .Where(x => x.Email == email)
                    .FirstOrDefaultAsync() ?? throw new Exception("Utilizador não encontrado.");

                var password = GenerateNewPassword();

                IdentityResult identityResult = await UpdateUserPassword(user, password);
                if (identityResult.Succeeded)
                {
                    await _emailService.SendEmailToUserResetPasswordAsync($"{user.FirstName} {user.LastName}", user.Email, password);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar criar uma nova palavra-passe do utilizador. Erro: {ex.Message}");
            }
        }

        public async Task UserUpdateUserPasswordAsync(UserLoginDTO userLoginDTO)
        {
            try
            {
                User? user = await _userRepository
                    .GetAll()
                    .Where(x => x.Email == userLoginDTO.Email)
                    .FirstOrDefaultAsync() ?? throw new Exception("Utilizador não encontrado.");

                IdentityResult identityResult = await UpdateUserPassword(user, userLoginDTO.Password);

                if (identityResult.Succeeded)
                {
                    await _emailService.SendEmailToUserUpdatePasswordAsync($"{user.FirstName} {user.LastName}", user.Email, userLoginDTO.Password);
                }  
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar enviar criar uma nova palavra-passe do utilizador. Erro: {ex.Message}");
            }
        }

        public async Task<bool> UserExists(string email)
        {
            try
            {
                return await _userManager.Users.AnyAsync(user => user.Email == email);

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar se o utilizador existe. Erro: {ex.Message}");

            }
        }

        public async Task<List<ResponseMessageDTO>> DeleteUsersAsync(List<int> usersIds)
        {
            List<ResponseMessageDTO> responseMessageDTOs = new();

            foreach (int userId in usersIds)
            {
                ResponseMessageDTO responseMessageDTO = new() { Entity = new MinimumDTO() { Id = userId }, OperationSuccess = false };
                try
                {
                    User? user = await _userRepository.FindByIdAsync(userId);

                    if (user != null)
                    {
                        responseMessageDTO.Entity.Name = user.Email;

                        if (user.IsDefault)
                        {
                            responseMessageDTO.ErrorMessage = "O Utilizador não pode ser apagado pois é administrador do sistema.";
                        }
                        else
                        {
                            await _userRepository.RemoveAsync(user);
                            responseMessageDTO.OperationSuccess = true;
                        }         
                    }
                    else
                    {
                        responseMessageDTO.ErrorMessage = "Utilizador não encontrado.";
                    }
                }

                catch (Exception ex)
                {
                    responseMessageDTO.ErrorMessage = ex.Message;
                }

                responseMessageDTOs.Add(responseMessageDTO);
            }

            return responseMessageDTOs;
        }

        private static string GenerateNewPassword()
        {
            Random rnd = new();
            return  rnd.Next(100000, 1000000000).ToString();
        }

        private async Task<IdentityResult> UpdateUserPassword(User user, string password)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return await _userManager.ResetPasswordAsync(user, token, password);
        }

    }
}
