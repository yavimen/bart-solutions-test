using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        protected ApplicationContext _context;
        protected IContactRepository? _contact;
        protected IAccountRepository? _account;
        protected IIncidentRepository? _incident;

        public RepositoryWrapper(ApplicationContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IAccountRepository Account 
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_context);
                }
                return _account;
            }
        }

        public IContactRepository Contact
        {
            get
            {
                if (_contact == null)
                {
                    _contact = new ContactRepository(_context);
                }
                return _contact;
            }
        }

        public IIncidentRepository Incident
        {
            get
            {
                if (_incident == null)
                {
                    _incident = new IncidentRepository(_context);
                }
                return _incident;
            }
        }
    }
}
