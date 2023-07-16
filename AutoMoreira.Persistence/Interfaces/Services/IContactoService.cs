namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IContactoService
    {
        Task<ContactoDTO> AddContactos(ContactoDTO model);
        Task<bool> DeleteContacto(int contactoId);

        Task<ContactoDTO[]> GetAllContactosAsync();
        Task<ContactoDTO> GetContactoByIdAsync(int contactoId);
    }
}
