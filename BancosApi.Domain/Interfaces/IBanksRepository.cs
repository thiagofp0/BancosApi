using BancosApi.Domain.Dao;

namespace BancosApi.Domain.Interfaces
{
    public interface IBanksRepository
    {
        public List<BanksDao> GetBanks();
    }
}
