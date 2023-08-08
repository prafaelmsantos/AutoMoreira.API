namespace AutoMoreira.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        #region Properties

        private readonly IContactService _contactService;

        #endregion

        #region Constructors
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Get All Contacts
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var contacts = await _contactService.GetAllContactsAsync();
                if (contacts == null) return NoContent();

                return Ok(contacts);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar contactos. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Get Contact
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var contact = await _contactService.GetContactByIdAsync(id);
                if (contact == null) return NoContent();

                return Ok(contact);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar o contacto. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Create Contact
        /// </summary>
        /// <param name="contactDTO"></param>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(ContactDTO contactDTO)
        {
            try
            {
                var contact = await _contactService.AddContact(contactDTO);
                if (contact == null) return NotFound("Erro ao tentar criar o contacto!");

                return Ok(contact);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar criar o contacto. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var contact = await _contactService.GetContactByIdAsync(id);
                if (contact == null) return NoContent();

                if (await _contactService.DeleteContact(id))
                {

                    return Ok(new { message = "Contacto apagado!" });

                }
                else
                {
                    throw new Exception("Contacto não apagado!");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar apagar o contacto. Erro: {ex.Message}");
            }
        }
        #endregion
    }
}
