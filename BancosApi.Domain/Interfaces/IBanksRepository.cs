using BancosApi.Domain.Entities;
using BancosApi.Domain.QueryObjects;

namespace BancosApi.Domain.Interfaces
{
    public interface IBanksRepository
    {
        public Task<IEnumerable<Bank>> GetBanks();
        public Task<Bank> GetBank(string id);
        public Task<bool> CreateBank(CreateBankQueryObject createBankQueryObject);
    }
}
