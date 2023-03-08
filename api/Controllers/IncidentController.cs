using AutoMapper;
using Contracts;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Controllers
{
    [Route("api/incident")]
    public class IncidentController : ControllerBase
    {
        protected readonly IRepositoryWrapper _repositories;
        protected readonly IMapper _mapper;

        public IncidentController(IRepositoryWrapper repositories, IMapper mapper) 
        { 
            _repositories = repositories;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIncidents() 
        {
            try
            {
                var incidents = await _repositories.Incident.GetAllIncidentsAsync();
                
                return Ok(incidents);
            }
            catch(Exception) 
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncident([FromBody] IncidentForCreationDto incidentDto) 
        {
            if (incidentDto is null)
            {
                return BadRequest("Incident object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var account = _mapper.Map<Account>(incidentDto);

            var accountInSystem = await _repositories.Account.GetAccountByNameAsync(account.Name);

            if (accountInSystem == null) 
            {
                return BadRequest("Account is not in the system.");
            }

            var contact = _mapper.Map<Contact>(incidentDto);

            var contactInSystem = await _repositories.Contact.GetContactByEmailAsync(contact.Email);

            try
            {
                if (contactInSystem != null)
                {
                    contactInSystem.Account = accountInSystem;

                    contactInSystem.AccountId = accountInSystem.AccountId;

                    if (accountInSystem.Contacts.FirstOrDefault(c => c.Email.Equals(contactInSystem.Email)) is null)
                        accountInSystem.Contacts.Add(contact);
                }
                else
                {
                    contact.ContactId = Guid.NewGuid();

                    contact.Account = accountInSystem;

                    contact.AccountId = accountInSystem.AccountId;

                    accountInSystem.Contacts.Add(contact);

                    _repositories.Contact.CreateContact(contact);
                }

                var incident = _mapper.Map<Incident>(incidentDto);
                incident.IncidentId = Guid.NewGuid();
                incident.Name = Guid.NewGuid().ToString();
                incident.Accounts = new List<Account>() { accountInSystem };

                accountInSystem.Incident = incident;
                accountInSystem.IncidentId = incident.IncidentId;

                _repositories.Incident.CreateIncident(incident);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

            await _repositories.SaveAsync();
            return Ok();
        }
    }
}
