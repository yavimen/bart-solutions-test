using Entities.Models;

namespace Contracts
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();

        Task<Contact?> GetContactByIdAsync(Guid id);

        Task<Contact?> GetContactByEmailAsync(string email);

        void CreateContact(Contact contact);

        void UpdateContact(Contact contact);

        void DeleteContact(Contact contact);
    }
}
