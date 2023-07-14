using BancosApi.Domain.Entities;
using BancosApi.Domain.Interfaces;

namespace BancosApi.Infrastructure
{
    public class SqliteRepository : IBanksRepository
    {
        public List<Bank> GetBanks()
        {
            throw new NotImplementedException();
        }

        public Bank GetBank(long id)
        {
            throw new NotImplementedException();
        }
    }
}
