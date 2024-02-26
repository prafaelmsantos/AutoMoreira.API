using Microsoft.AspNetCore.Identity;

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
        private readonly IUserRoleRepository _userRoleRepository;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, 
            IMapper mapper, IUserRepository userRepository, IEmailService emailService, 
            IRoleRepository roleRepository, IUserRoleRepository userRoleRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userRepository = userRepository;
            _emailService = emailService;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }
        public async Task<SignInResult> CheckUserPasswordAsync(UserDTO userDTO, string password)
        {
            try
            {
                User? user = await _userManager.Users.SingleOrDefaultAsync(user => user.UserName == userDTO.UserName.ToLower() || user.UserName == userDTO.Email.ToLower());

                return await _signInManager.CheckPasswordSignInAsync(user!, password, false);

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar password. Erro: {ex.Message}");

            }
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            try
            {
                if (userDTO.Roles.Count() == 0) throw new Exception("Nenhum cargo encontrado.");

                User user = new(userDTO.UserName, userDTO.Email, userDTO.PhoneNumber, userDTO.FirstName, userDTO.LastName);


                Role? role = await _roleRepository.FindByIdAsync(userDTO.Roles.FirstOrDefault()!.Id);

                user.SetRoles(new List<Role> { role });


                string password = GenerateNewPassword();

                IdentityResult identityResult = await _userManager.CreateAsync(user, password);

                if (identityResult.Succeeded)
                {
                    await _emailService.SendEmailToUserAsync($"{user.FirstName} {user.LastName}", user.Email, user.UserName, password);
                    return _mapper.Map<UserDTO>(user);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar criar conta de utilizador!. Erro: {ex.Message}");

            }
        }

        public async Task<UserDTO> GetUserByUserNameOrEmailAsync(string userName)
        {
            User? user = await _userRepository.GetAll().Where(x => x.UserName == userName || x.Email == userName).FirstOrDefaultAsync();

            if (user == null) throw new Exception("Utilizador não encontrado.");

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            try
            {
                User? user = await _userRepository.GetAll()
                    .Where(x=> x.Id == id)
                    .Include(x => x.Roles)
                    .FirstOrDefaultAsync();
                
                if (user == null) throw new Exception("Utilizador não encontrado.");

                return _mapper.Map<UserDTO>(user);

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar procurar utilizador por Username. Erro: {ex.Message}");
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
                User user = await _userRepository.FindByIdAsync(userDTO.Id);

                if (user == null) throw new Exception("Utilizador não encontrado.");

                user.UpdateUser(userDTO.UserName, userDTO.Email, userDTO.PhoneNumber, userDTO.FirstName, userDTO.LastName, userDTO.Image, userDTO.DarkMode);

                await _userRoleRepository.RemoveRangeAsync(_userRoleRepository.GetAll().Where(x => x.UserId == userDTO.Id).ToList());

                Role? role = await _roleRepository.FindByIdAsync(userDTO.Roles.FirstOrDefault()!.Id);

                user.SetRoles(new List<Role> { role });


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

        public async Task<UserDTO> UpdateUserModeAsync(UserUpdateModeDTO userUpdateModeDTO)
        {
            try
            {
                User user = await _userRepository.FindByIdAsync(userUpdateModeDTO.Id);

                if (user == null) throw new Exception("Utilizador não encontrado.");

                user.SetDarkMode(userUpdateModeDTO.DarkMode);

                await _userRepository.UpdateAsync(user);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar o modo de utilizador. Erro: {ex.Message}");
            }
        }

        public async Task<UserDTO> UpdateUserImageAsync(UserUpdateImageDTO userUpdateImageDTO)
        {
            try
            {
                User user = await _userRepository.FindByIdAsync(userUpdateImageDTO.Id);

                if (user == null) throw new Exception("Utilizador não encontrado.");

                user.SetImage(userUpdateImageDTO.Image);

                await _userRepository.UpdateAsync(user);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar o modo de utilizador. Erro: {ex.Message}");
            }
        }

        public async Task UserResetPasswordAsync(string userName)
        {
            try
            {
                User? user = await _userRepository.GetAll().Where(x => x.UserName == userName || x.Email == userName).FirstOrDefaultAsync();

                if (user == null) throw new Exception("Utilizador não encontrado.");

                var password = GenerateNewPassword();

                IdentityResult identityResult = await UpdateUserPassword(user, password);
                if (identityResult.Succeeded)
                {
                    await _emailService.SendEmailToUserResetPasswordAsync($"{user.FirstName} {user.LastName}", user.Email, password);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar enviar criar uma nova palavra-passe do utilizador. Erro: {ex.Message}");
            }
        }

        public async Task UserUpdateUserPasswordAsync(string userName, string password)
        {
            try
            {
                User? user = await _userRepository.GetAll().Where(x => x.UserName == userName || x.Email == userName).FirstOrDefaultAsync();

                if (user == null) throw new Exception("Utilizador não encontrado.");

                await UpdateUserPassword(user, password);

                await _emailService.SendEmailToUserUpdatePasswordAsync($"{user.FirstName} {user.LastName}", user.Email, password);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar enviar criar uma nova palavra-passe do utilizador. Erro: {ex.Message}");
            }
        }

        public async Task<bool> UserExists(string userName)
        {
            try
            {
                return await _userManager.Users.AnyAsync(user => user.UserName == userName.ToLower());

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar se o utilizador existe. Erro: {ex.Message}");

            }
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
