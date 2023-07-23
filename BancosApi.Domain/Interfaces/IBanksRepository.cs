using BancosApi.Domain.Entities;

namespace BancosApi.Domain.Interfaces
{
    public interface IBanksRepository
    {
        public Task<IEnumerable<Bank>> GetBanks();
        public Task<Bank> GetBank(string id);
    }
}
