namespace AutoMoreira.Persistence.Services
{
    public class ContactService : IContactService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(
        IBaseRepository baseRepository,
        IContactRepository contactRepository,
        IMapper mapper)
        {
            _baseRepository = baseRepository;
            _contactRepository = contactRepository;
            _mapper = mapper;

        }
        public async Task<ContactDTO> AddContact(ContactDTO contactDTO)
        {
            try
            {

                var contact = _mapper.Map<Contact>(contactDTO);
                _baseRepository.Add<Contact>(contact);

                if (await _baseRepository.SaveChangesAsync())
                {
                    var result = await _contactRepository.GetContactByIdAsync(contact.Id);
                    return _mapper.Map<ContactDTO>(result);
                }
                return null;
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
                var contact = await _contactRepository.GetContactByIdAsync(contactId);
                if (contact == null) throw new Exception("Contacto não encontrado.");

                _baseRepository.Delete<Contact>(contact);
                return await _baseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ContactDTO[]> GetAllContactsAsync()
        {
            try
            {
                var contacts = await _contactRepository.GetAllContactsAsync();
                if (contacts == null) return null;

                return _mapper.Map<ContactDTO[]>(contacts);

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
                var contact = await _contactRepository.GetContactByIdAsync(contactId);
                if (contact == null) return null;

                return _mapper.Map<ContactDTO>(contact);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
