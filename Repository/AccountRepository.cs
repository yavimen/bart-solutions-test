using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationContext context):
            base(context){ }

        public void CreateAccount(Account account)
        {
            Create(account);
        }

        public void DeleteAccount(Account account)
        {
            Delete(account);
        }

        public async Task<Account?> GetAccountByIdAsync(Guid id)
        {
            return await FindByCondition(a => a.AccountId.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<Account?> GetAccountByNameAsync(string name)
        {
            return await FindByCondition(a => a.Name.Equals(name))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await FindAll()
                .OrderBy(a => a.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAccountsWithDetailsAsync()
        {
            return await FindAll()
                .Include(a => a.Contacts)
                .OrderBy(a => a.Name)
                .ToListAsync();
        }

        public void UpdateAccount(Account account)
        {
            Update(account);
        }
    }
}
