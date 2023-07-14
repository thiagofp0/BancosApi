using BancosApi.Domain.Entities;
using BancosApi.Domain.Interfaces;

namespace BancosApi.Infrastructure
{
    public class SqliteRepository : IBanksRepository
    {
        public List<Bank> GetBanks()
        {
            return new List<Bank>()
            {
                new Bank(1, "123456", "Banco do Brasil", "BB"),
                new Bank(2, "123457", "Bradesco S.A.", "Bradesco"),
                new Bank(3, "123458", "Nu Pagamentos S.A.", "Nubank"),
            };
        }

        public Bank GetBank(long id)
        {
            return new Bank(id, "12345", "Banco Teste", "BT");
        }
    }
}
