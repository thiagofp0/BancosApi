using AutoMapper;
using BancosApi.Domain.Interfaces;
using BancosApi.Domain.QueryObjects;
using BancosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BancosApi.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly ILogger<BanksController> _logger;
        private readonly IBanksRepository _banksRepository;
        private readonly IMapper _mapper;

        public BanksController(ILogger<BanksController> logger, IBanksRepository banksRepository, IMapper mapper)
        {
            _logger = logger;
            _banksRepository = banksRepository;
            _mapper = mapper;
        }
        
        [HttpGet("Banks")]
        public async Task<ObjectResult> GetAll()
        {
            _logger.LogInformation("Start Getting all banks at {DT}", DateTime.UtcNow.ToLongTimeString());

            var banks = await _banksRepository.GetBanks();

            return Ok(banks);
        }


        [HttpGet("Banks/{id}")]
        public async Task<ObjectResult> Get(long id)
        {
            _logger.LogInformation("Start Getting bank by id = {ID} at {DT}", id, DateTime.UtcNow.ToLongTimeString());

            var idString = string.Format("{0:000}", id);
            var bank = await _banksRepository.GetBank(idString);

            if (bank == null)
                return NotFound("No Banks found for given id.");
            
            return Ok(bank);
        }

        [HttpPost("Banks")]
        public async Task<ObjectResult> Post([FromBody] BanksRequestApiModel banksRequestApiModel)
        {
            _logger.LogInformation("Start Creating bank at {DT}", DateTime.UtcNow.ToLongTimeString());

            var queryObject = _mapper.Map<CreateBankQueryObject>(banksRequestApiModel);

            var result = await _banksRepository.CreateBank(queryObject);

            return Ok(result);
        }
    }
}
