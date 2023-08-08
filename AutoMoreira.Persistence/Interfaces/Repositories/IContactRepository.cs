namespace AutoMoreira.Persistence.Interfaces.Repositories
{
    public interface IContactRepository
    {
        Task<Contact[]> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(int contactId);
    }
}
