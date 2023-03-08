using Entities.Models;

namespace Contracts
{
    public interface IIncidentRepository
    {
        Task<IEnumerable<Incident>> GetAllIncidentsAsync();

        Task<Incident?> GetIncidentByIdAsync(Guid id);

        void CreateIncident(Incident incident);

        void UpdateIncident(Incident incident);

        void DeleteIncident(Incident incident);
    }
}
