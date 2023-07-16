namespace AutoMoreira.Persistence.Interfaces.Repositories
{
    public interface IContactoRepository
    {
        Task<Contacto[]> GetAllContactosAsync();
        Task<Contacto> GetContactoByIdAsync(int contactoId);
    }
}
