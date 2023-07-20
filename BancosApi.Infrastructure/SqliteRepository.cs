using Dapper;
using BancosApi.Domain.Entities;
using BancosApi.Domain.Interfaces;
using BancosApi.Infrastructure.Database;
using BancosApi.Infrastructure.Models;
using AutoMapper;

namespace BancosApi.Infrastructure
{
    public class SqliteRepository : IBanksRepository
    {
        private const string GET_BANKS = "SELECT * FROM Banks";
        private const string GET_BANK = "SELECT * FROM Banks WHERE id=@Id";

        private readonly DbConnection _connection = new();
        private readonly IMapper _mapper;

        public SqliteRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<Bank> GetBanks()
        {
            var banks = Query<BankDatabaseModel>(GET_BANKS);
            return _mapper.Map<IEnumerable<Bank>>(banks);
        }

        public Bank GetBank(long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var bank = Query<Bank>(GET_BANK, parameters);
            return _mapper.Map<Bank>(bank.FirstOrDefault()) ?? throw new KeyNotFoundException("No Banks found for given id.");
        }

        private IEnumerable<T> Query<T>(string sql, object? parameters = null)
        {
            using var connectionClient = _connection.GetConnection();
            return connectionClient.Query<T>(new CommandDefinition(sql, parameters));
        }
    }
}
