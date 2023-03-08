using Entities.Models;

namespace Entities
{
    public class InitialData
    {
        public List<Contact> Contacts { get; protected set; }
        public List<Account> Accounts { get; protected set; }
        public List<Incident> Incidents { get; protected set; }
        public InitialData() 
        {
            Contacts = new List<Contact>() 
            {
                new Contact() { Email="emailam@gmail.com", FirstName="Alek", LastName="Markovych", ContactId=Guid.NewGuid() },
                new Contact() { Email="vinve@gmail.com", FirstName="Vinsent", LastName="Vega", ContactId=Guid.NewGuid() },
                new Contact() { Email="ruco@gmail.com", FirstName="Rust", LastName="Cohle", ContactId=Guid.NewGuid() }
            };

            Accounts = new List<Account>()
            {
                new Account(){ AccountId=Guid.NewGuid(), Name="mystery007" },
                new Account(){ AccountId=Guid.NewGuid(), Name="fastestgun" },
                new Account(){ AccountId=Guid.NewGuid(), Name="intellectual" }
            };
            Contacts[0].AccountId = Accounts[0].AccountId;
            Contacts[1].AccountId = Accounts[1].AccountId;
            Contacts[2].AccountId = Accounts[2].AccountId;
            Incidents = new List<Incident>()
            {
                new Incident(){ IncidentId = Guid.NewGuid(), Description="Some descr.", Name="Incident1" },
                new Incident(){ IncidentId = Guid.NewGuid(), Description="Some special descr.", Name="Incident2" }
            };
            Accounts[0].IncidentId = Incidents[0].IncidentId;
            Accounts[1].IncidentId = Incidents[0].IncidentId;
            Accounts[2].IncidentId = Incidents[1].IncidentId;
        }
    }
}
