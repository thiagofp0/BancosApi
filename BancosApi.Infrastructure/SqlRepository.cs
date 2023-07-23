using AutoMapper;
using BancosApi.Domain.Base.Adapters;
using BancosApi.Domain.Base.Exceptions;
using BancosApi.Domain.Entities;
using BancosApi.Domain.Interfaces;
using BancosApi.Infrastructure.Models;
using Dapper;
using MySqlConnector;

namespace BancosApi.Infrastructure
{
    public class SqlRepository : IBanksRepository
    {
        private const string GET_BANKS = "SELECT * FROM Banks";
        private const string GET_BANK = "SELECT * FROM Banks WHERE Compe=@Compe";

        private readonly ISqlDatabaseAdapter<MySqlConnection> _connection;
        private readonly IMapper _mapper;

        public SqlRepository(IMapper mapper, ISqlDatabaseAdapter<MySqlConnection> connection)
        {
            _mapper = mapper;
            _connection = connection;
        }

        public async Task<Bank> GetBank(string id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Compe", id);
            var bank = await QueryAsync<BankDatabaseModel>(GET_BANK, parameters);
            return _mapper.Map<Bank>(bank.FirstOrDefault()) ?? throw new NoResultsException("No Banks found for given id.");
        }

        public async Task<IEnumerable<Bank>> GetBanks()
        {
            var banks = await QueryAsync<BankDatabaseModel>(GET_BANKS);
            return _mapper.Map<IEnumerable<Bank>>(banks);
        }

        private async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null)
        {
            using var connectionClient = _connection.GetConnection();
            return await connectionClient.QueryAsync<T>(new CommandDefinition(sql, parameters));
        }
    }
}
