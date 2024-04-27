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
            return Ok(await _userService.GetAllUsersAsync());
        }

        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _userService.GetUserByIdAsync(id));
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
                if (await _userService.UserExists(userDTO.Email))
                {
                    return BadRequest("O utilizador já existe!");
                }
                var user = await _userService.CreateUserAsync(userDTO);
                if (user != null)
                {
                    return Ok(new UserDTO
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Image = user.Image,
                        PhoneNumber = user.PhoneNumber,
                        DarkMode = user.DarkMode,
                        IsDefault = user.IsDefault,
                        Roles = user.Roles,
                        Token = _tokenService.CreateToken(user).Result
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
            UserDTO userDTO = await _userService.GetUserByEmailAsync(userLoginDTO.Email);
            if (!await _userService.CheckUserPasswordAsync(userDTO, userLoginDTO.Password))
            {
                return Unauthorized();
            }

            userDTO.Token = _tokenService.CreateToken(userDTO).Result;

            return Ok(userDTO);
        }

        /// <summary>
        /// Reset User Password
        /// </summary>
        /// <param name="email"></param>
        [HttpPost("ResetPassword/{email}")]
        public async Task<IActionResult> ResetPassword([FromRoute] string email)
        {
            await _userService.UserResetPasswordAsync(email);
            return Ok(email);
        }

        /// <summary>
        /// Update User Password
        /// </summary>
        /// <param name="userLoginDTO"></param>
        [HttpPut("UpdatePassword")]
        public async Task<IActionResult>UpdatePassword([FromBody] UserLoginDTO userLoginDTO)
        {
            return Ok(_userService.UserUpdateUserPasswordAsync(userLoginDTO));
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="userDTO"></param>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDTO)
        {
            userDTO.Id = id;
            return Ok(await _userService.UpdateUserAsync(userDTO));
        }

        /// <summary>
        /// Update User Mode
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="id"></param>
        [HttpPut("Mode/{id}")]
        public async Task<IActionResult> UpdateUserMode(int id, [FromBody] bool mode)
        {
            return Ok(await _userService.UpdateUserModeAsync(id, mode));
        }

        /// <summary>
        /// Update User Image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="id"></param>
        [HttpPut("Image/{id}")]
        public async Task<IActionResult> UpdateUserImage(int id, [FromBody] string image)
        {
            return Ok(await _userService.UpdateUserImageAsync(id, image));
        }

        //// <summary>
        /// Delete Users
        /// </summary>
        /// <param name="usersIds"></param>
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> usersIds)
        {
            return Ok(await _userService.DeleteUsersAsync(usersIds));
        }
        #endregion

    }
}
