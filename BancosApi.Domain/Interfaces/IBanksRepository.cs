using BancosApi.Domain.Entities;

namespace BancosApi.Domain.Interfaces
{
    public interface IBanksRepository
    {
        public IEnumerable<Bank> GetBanks();
        public Bank GetBank(long id);
    }
}
