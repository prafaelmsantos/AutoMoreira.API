namespace AutoMoreira.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Properties

        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        #endregion


        #region Constructors
        public UsersController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Get All Users
        /// </summary>
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                if (users == null) return NoContent();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar utilizadores. Erro: {ex.Message}");
            }

        }

        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                UserDTO userDTO = await _userService.GetUserByIdAsync(id);
                if (userDTO == null) return NoContent();

                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar o utilizador. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="userDTO"></param>
        [HttpPost()]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDTO)
        {
            try
            {
                if (await _userService.UserExists(userDTO.UserName))
                {
                    return BadRequest("O utilizador já existe!");
                }
                var user = await _userService.CreateUserAsync(userDTO);
                if (user != null)
                {
                    return Ok(new
                    {
                        userName = user.UserName,
                        firstName = user.FirstName,
                        lastName = user.LastName,
                        token = _tokenService.CreateToken(user).Result

                    });
                }
                return BadRequest("Utilizador não criado! Tente mais tarde...");


            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar criar conta utilizador. Erro: {ex.Message}");
            }

        }


        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="userLoginDTO"></param>
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO userLoginDTO)
        {
            try
            {
                //Verifica se o utilizador existe
                var user = await _userService.GetUserByUserNameAsync(userLoginDTO.UserName);
                if (user == null)
                {
                    return Unauthorized("Utilizador ou password inválida!");
                }
                //Verificar se o username e a senha estao bem
                var result = await _userService.CheckUserPasswordAsync(user, userLoginDTO.Password);
                if (!result.Succeeded)
                {
                    return Unauthorized();
                }
                return Ok(new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DarkMode = user.DarkMode,
                    Token = _tokenService.CreateToken(user).Result
                });

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar fazer Login. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="userUpdateDTO"></param>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDTO)
        {
            try
            {
                userDTO.Id = id;
                UserDTO userUpdate = await _userService.UpdateUserAsync(userDTO);
                if (userUpdate == null) return NoContent();

                return Ok(userUpdate);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar Utilizador. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Update User Mode
        /// </summary>
        /// <param name="userUpdateModeDTO"></param>
        /// <param name="id"></param>
        [HttpPut("Mode/{id}")]
        public async Task<IActionResult> UpdateUserMode(int id, [FromBody] UserUpdateModeDTO userUpdateModeDTO)
        {
            try
            {
                userUpdateModeDTO.Id = id;
                UserDTO userDTO = await _userService.UpdateUserModeAsync(userUpdateModeDTO);
                if (userDTO == null) return NoContent();

                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar o modo de utilizador. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Update User Image
        /// </summary>
        /// <param name="userUpdateImageDTO"></param>
        /// <param name="id"></param>
        [HttpPut("Image/{id}")]
        public async Task<IActionResult> UpdateUserImage(int id, [FromBody] UserUpdateImageDTO userUpdateImageDTO)
        {
            try
            {
                userUpdateImageDTO.Id = id;
                UserDTO userDTO = await _userService.UpdateUserImageAsync(userUpdateImageDTO);
                if (userDTO == null) return NoContent();

                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar o modo de utilizador. Erro: {ex.Message}");
            }
        }
        #endregion

    }
}
