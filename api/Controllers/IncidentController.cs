using AutoMapper;
using Contracts;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

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

        // https://localhost:7099/api/incident
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

        // https://localhost:7099/api/incident/details
        [HttpGet("details")]
        public async Task<IActionResult> GetAllIncidentsWithDetails()
        {
            try
            {
                var incidents = await _repositories.Incident.GetAllIncidentsWithContactsAsync();

                return Ok(incidents);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }


        //https://localhost:7099/api/incident
        //{
        //    "accountname":"test",
        //    "email":"test@gmail.com",
        //    "firstname":"test",
        //    "lastname":"test",
        //    "incidentdescription":"test"
        //}
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

            if (accountInSystem is null) 
            {
                return BadRequest("Account is not in the system.");
            }

            var contact = _mapper.Map<Contact>(incidentDto);

            var contactInSystem = await _repositories.Contact.GetContactByEmailAsync(contact.Email);

            if (contactInSystem != null && contactInSystem.AccountId != accountInSystem.AccountId)
            {
                return BadRequest("Email belongs to another account.");
            }

            try
            {
                if (contactInSystem != null)
                {
                    contactInSystem.FirstName = contact.FirstName;

                    contactInSystem.LastName = contact.LastName;

                    _repositories.Contact.UpdateContact(contactInSystem);
                }
                else
                {
                    contact.ContactId = Guid.NewGuid();

                    contact.AccountId = accountInSystem.AccountId;

                    _repositories.Contact.CreateContact(contact);
                }

                var incident = _mapper.Map<Incident>(incidentDto);

                incident.IncidentId = Guid.NewGuid();

                incident.Name = Guid.NewGuid().ToString();

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
