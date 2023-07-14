using BancosApi.Domain.Entities;

namespace BancosApi.Domain.Interfaces
{
    public interface IBanksRepository
    {
        public List<Bank> GetBanks();
        public Bank GetBank(long id);
    }
}
