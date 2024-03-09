namespace AutoMoreira.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        #region Properties

        private readonly IRoleService _roleService;

        #endregion

        #region Constructors

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        #endregion

        #region CRUD Methods

        /// <summary>
        /// Get All Roles
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var roles = await _roleService.GetAllRolesAsync();
                if (roles == null) return NoContent();

                return Ok(roles);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar cargos de utilizaor. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Get Role
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var role = await _roleService.GetRoleByIdAsync(id);
                if (role == null) return NoContent();

                return Ok(role);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar o cargo de utilizador. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Create Role
        /// </summary>
        /// <param name="roleDTO"></param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleDTO roleDTO)
        {
            try
            {
                var role = await _roleService.AddRoleAsync(roleDTO);
                if (role == null) return NotFound("Erro a criar o cargo de utilizador!");

                return Ok(role);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar criar o cargo de utilizador. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Update Mark
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleDTO"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RoleDTO roleDTO)
        {
            try
            {
                roleDTO.Id = id;
                var role = await _roleService.UpdateRoleAsync(roleDTO);
                if (role == null) return NoContent();

                return Ok(role);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar o cargo de utilizador. Erro: {ex.Message}");
            }
        }

        //// <summary>
        /// Delete Roles
        /// </summary>
        /// <param name="rolesIds"></param>
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> rolesIds)
        {
            return Ok(await _roleService.DeleteRolesAsync(rolesIds));
        }

        #endregion

    }
}
