using Dapper;
using BancosApi.Domain.Entities;
using BancosApi.Domain.Interfaces;
using BancosApi.Infrastructure.Database;

namespace BancosApi.Infrastructure
{
    public class SqliteRepository : IBanksRepository
    {
        private const string GET_BANKS = "SELECT * FROM Banks";
        private const string GET_BANK = "SELECT * FROM Banks WHERE id=@Id";

        private readonly DbConnection _connection = new();

        public IEnumerable<Bank> GetBanks()
        {
            // TODO: Conexão com o banco está pegando caminho errado até o arquivo - Ideal seria colocar em uma connection string
            // TODO: Retorno do banco precisa ser tratado para que seja exibido corretamente.
            // TODO: no retorno do banco colocar BankApiModel e criar Mapping para classe mais resumida
            var banks = Query<Bank>(GET_BANKS);
            return banks;
        }

        public Bank GetBank(long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var bank = Query<Bank>(GET_BANK, parameters);
            return bank.FirstOrDefault() ?? throw new KeyNotFoundException("No Banks found for given id.");
        }

        private IEnumerable<T> Query<T>(string sql, object? parameters = null)
        {
            using var connectionClient = _connection.GetConnection();
            return connectionClient.Query<T>(new CommandDefinition(sql, parameters));
        }
    }
}
