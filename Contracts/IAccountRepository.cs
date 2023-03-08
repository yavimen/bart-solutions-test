
using Entities.Models;

namespace Contracts
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();

        Task<Account?> GetAccountByIdAsync(Guid id);

        Task<Account?> GetAccountByNameAsync(string name);

        void CreateAccount(Account account);

        void UpdateAccount(Account account);

        void DeleteAccount(Account account);
    }
}
