using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class IncidentRepository : RepositoryBase<Incident>, IIncidentRepository
    {
        public IncidentRepository(ApplicationContext context)
            : base(context)
        {
        }
        public void CreateIncident(Incident incident)
        {
            Create(incident);
        }

        public void DeleteIncident(Incident incident)
        {
            Delete(incident);
        }

        public async Task<IEnumerable<Incident>> GetAllIncidentsAsync()
        {
            return await FindAll()
                .OrderBy(i => i.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Incident>> GetAllIncidentsWithContactsAsync()
        {
            return await FindAll()
                .Include(i=>i.Accounts).IgnoreAutoIncludes()
                .OrderBy(i => i.Name)
                .ToListAsync();
        }

        public async Task<Incident?> GetIncidentByIdAsync(Guid id)
        {
            return await FindByCondition(i => i.IncidentId.Equals(id))
                .FirstOrDefaultAsync();
        }

        public void UpdateIncident(Incident incident)
        {
            Update(incident);
        }
    }
}
