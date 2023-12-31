﻿namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IContactService
    {
        Task<ContactDTO> AddContact(ContactDTO contactDTO);
        Task<bool> DeleteContact(int contactoId);

        Task<List<ContactDTO>> GetAllContactsAsync();
        Task<ContactDTO> GetContactByIdAsync(int contactId);
    }
}
