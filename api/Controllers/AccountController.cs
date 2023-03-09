using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {

        protected readonly IRepositoryWrapper _repositories;

        public AccountController(IRepositoryWrapper repositories, IMapper mapper)
        {
            _repositories = repositories;
        }

        // https://localhost:7099/api/account
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts() 
        {
            try 
            {
                var accounts = await _repositories.Account.GetAllAccountsAsync();

                return Ok(accounts);
            }
            catch (Exception) 
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        // https://localhost:7099/api/account/details
        [HttpGet("details")]
        public async Task<IActionResult> GetAllAccountsWithDetails()
        {
            try
            {
                var accounts = await _repositories.Account.GetAllAccountsWithDetailsAsync();

                return Ok(accounts);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
