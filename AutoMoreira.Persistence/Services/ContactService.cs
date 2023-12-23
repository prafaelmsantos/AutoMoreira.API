namespace AutoMoreira.Persistence.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(
        IContactRepository contactRepository,
        IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;

        }
        public async Task<ContactDTO> AddContact(ContactDTO contactDTO)
        {
            try
            {

                Contact contact = _mapper.Map<Contact>(contactDTO);
                await _contactRepository.AddAsync(contact);

                return _mapper.Map<ContactDTO>(contact);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> DeleteContact(int contactId)
        {
            try
            {
                Contact contact = await _contactRepository.FindByIdAsync(contactId);
                if (contact == null) throw new Exception("Contacto não encontrado.");

                return await _contactRepository.RemoveAsync(contact);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ContactDTO>> GetAllContactsAsync()
        {
            try
            {
                List<Contact> contacts = await _contactRepository.GetAll().ToListAsync();

                return _mapper.Map<List<ContactDTO>>(contacts);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ContactDTO> GetContactByIdAsync(int contactId)
        {
            try
            {
                Contact contact = await _contactRepository.FindByIdAsync(contactId);
                if (contact == null) throw new Exception("Contacto não encontrado.");

                return _mapper.Map<ContactDTO>(contact);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
