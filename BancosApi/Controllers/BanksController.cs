using BancosApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BancosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly ILogger<BanksController> _logger;

        public BanksController(ILogger<BanksController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet(Name = "Banks")]
        public IEnumerable<BankApiModel> Get()
        {
            throw new NotImplementedException();
        }

    }
}
