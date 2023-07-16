﻿namespace AutoMoreira.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        #region Properties

        private readonly IContactoService _contactoService;

        #endregion

        #region Constructors
        public ContactosController(IContactoService contactoService)
        {
            _contactoService = contactoService;
        }
        #endregion

        #region CRUD Methods

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var contactos = await _contactoService.GetAllContactosAsync();
                if (contactos == null) return NoContent();

                return Ok(contactos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar contactos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var contacto = await _contactoService.GetContactoByIdAsync(id);
                if (contacto == null) return NoContent();

                return Ok(contacto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar contactos. Erro: {ex.Message}");
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(ContactoDTO model)
        {
            try
            {
                var contacto = await _contactoService.AddContactos(model);
                if (contacto == null) return NotFound("Erro a criar o contacto!");

                return Ok(contacto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar contactos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var marca = await _contactoService.GetContactoByIdAsync(id);
                if (marca == null) return NoContent();

                if (await _contactoService.DeleteContacto(id))
                {

                    return Ok(new { message = "Apagado" });

                }
                else
                {
                    throw new Exception("Contacto não apagado");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar apagar contactos. Erro: {ex.Message}");
            }
        }
        #endregion
    }
}
