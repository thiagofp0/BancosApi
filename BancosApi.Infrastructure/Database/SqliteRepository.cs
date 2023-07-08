using BancosApi.Domain.Dao;
using BancosApi.Domain.Interfaces;

namespace BancosApi.Infrastructure.Database
{
    public class SqliteRepository : IBanksRepository
    {
        public List<BanksDao> GetBanks()
        {
            throw new NotImplementedException();
        }
    }
}
