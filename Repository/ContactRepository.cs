using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationContext context)
            : base(context)
        {
        }

        public void CreateContact(Contact contact)
        {
            Create(contact);
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await FindAll()
                .OrderBy(c => c.Email)
                .ToListAsync();
        }

        public async Task<Contact?> GetContactByIdAsync(Guid id)
        {
            return await FindByCondition(o => o.ContactId.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<Contact?> GetContactByEmailAsync(string email)
        {
            return await FindByCondition(o => o.Email.Equals(email))
                .FirstOrDefaultAsync();
        }

        public void UpdateContact(Contact contact)
        {
            Update(contact);
        }

        public void DeleteContact(Contact contact)
        {
            Delete(contact);
        }
    }
}
