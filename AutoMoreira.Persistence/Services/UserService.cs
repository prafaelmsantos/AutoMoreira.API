namespace AutoMoreira.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateDTO userUpdateDto, string password)
        {
            try
            {
                User user = await _userManager.Users.SingleOrDefaultAsync(user => user.UserName == userUpdateDto.UserName.ToLower());

                return await _signInManager.CheckPasswordSignInAsync(user, password, false);

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar password. Erro: {ex.Message}");

            }
        }

        public async Task<UserUpdateDTO> CreateUserAsync(UserDTO userDTO)
        {
            try
            {
                User user = _mapper.Map<User>(userDTO);

                IdentityResult identityResult = await _userManager.CreateAsync(user, userDTO.Password);

                if (identityResult.Succeeded)
                {
                    UserUpdateDTO userUpdateDTO = _mapper.Map<UserUpdateDTO>(user);
                    return userUpdateDTO;
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar criar conta de utilizador!. Erro: {ex.Message}");

            }
        }

        public async Task<UserUpdateDTO> GetUserByUserNameAsync(string userName)
        {
            try
            {
                User user = await _userRepository.FindByCondition(x=> x.UserName == userName).FirstOrDefaultAsync();
                
                if (user == null) throw new Exception("Utilizador não encontrado.");

                UserUpdateDTO userUpdateDTO = _mapper.Map<UserUpdateDTO>(user);
                return userUpdateDTO;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar procurar utilizador por Username. Erro: {ex.Message}");

            }
        }

        public async Task<UserUpdateDTO> GetUserByIdAsync(int id)
        {
            try
            {
                User user = await _userRepository.FindByIdAsync(id);
                
                if (user == null) throw new Exception("Utilizador não encontrado.");

                UserUpdateDTO userUpdateDTO = _mapper.Map<UserUpdateDTO>(user);
                return userUpdateDTO;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar procurar utilizador por Username. Erro: {ex.Message}");

            }
        }
        public async Task<List<UserUpdateDTO>> GetAllUsersAsync()
        {
            try
            {
                List<User> users = await _userRepository.GetAll().ToListAsync();

                return _mapper.Map<List<UserUpdateDTO>>(users);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserUpdateDTO> UpdateUserAsync(UserUpdateDTO userUpdateDTO)
        {
            try
            {
                User user = await _userRepository.FindByIdAsync(userUpdateDTO.Id);

                if (user == null) throw new Exception("Utilizador não encontrado.");

                userUpdateDTO.Id = user.Id;

                _mapper.Map(userUpdateDTO, user);

                if (userUpdateDTO.Password != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    await _userManager.ResetPasswordAsync(user, token, userUpdateDTO.Password);
                }
                
                await _userRepository.UpdateAsync(user);

                return _mapper.Map<UserUpdateDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar utilizador. Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDTO> UpdateUserModeAsync(UserUpdateModeDTO userUpdateModeDTO)
        {
            try
            {
                User user = await _userRepository.FindByIdAsync(userUpdateModeDTO.Id);

                if (user == null) throw new Exception("Utilizador não encontrado.");

                user.SetDarkMode(userUpdateModeDTO.DarkMode);

                await _userRepository.UpdateAsync(user);

                return _mapper.Map<UserUpdateDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar o modo utilizador. Erro: {ex.Message}");
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
    }
}
