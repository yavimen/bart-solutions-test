namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IAccountRepository Account { get; }
        IContactRepository Contact { get; }
        IIncidentRepository Incident { get; }
        Task SaveAsync();
    }
}
