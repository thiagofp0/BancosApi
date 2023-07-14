using BancosApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BancosApi.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly ILogger<BanksController> _logger;
        private readonly IBanksRepository _banksRepository;

        public BanksController(ILogger<BanksController> logger, IBanksRepository banksRepository)
        {
            _logger = logger;
            _banksRepository = banksRepository;
        }
        
        [HttpGet("Banks")]
        public ObjectResult GetAll()
        {
            _logger.LogInformation("Start Getting all banks at {DT}", DateTime.UtcNow.ToLongTimeString());

            var banks = _banksRepository.GetBanks();

            return Ok(banks);
        }


        [HttpGet("Banks/{id}")]
        public ObjectResult Get(long id)
        {
            _logger.LogInformation("Start Getting bank by id = {ID} at {DT}", id, DateTime.UtcNow.ToLongTimeString());

            var bank = _banksRepository.GetBank(id);

            return Ok(bank);
        }

    }
}
