using AutoMapper;
using BancosApi.Domain.Entities;
using BancosApi.Domain.Interfaces;
using BancosApi.Infrastructure.Database;
using BancosApi.Infrastructure.Models;
using Dapper;

namespace BancosApi.Infrastructure
{
    public class SqlRepository : IBanksRepository
    {
        private const string GET_BANKS = "SELECT * FROM Banks";
        private const string GET_BANK = "SELECT * FROM Banks WHERE Compe=@Compe";

        private readonly DbConnection _connection;
        private readonly IMapper _mapper;

        public SqlRepository(IMapper mapper, DbConnection connection)
        {
            _mapper = mapper;
            _connection = connection;
        }

        public async Task<Bank> GetBank(string id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Compe", id);
                var bank = await QueryAsync<BankDatabaseModel>(GET_BANK, parameters);
                return _mapper.Map<Bank>(bank.FirstOrDefault()) ?? throw new KeyNotFoundException("No Banks found for given id.");
            }
            catch (KeyNotFoundException ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Bank>> GetBanks()
        {
            var banks = await QueryAsync<BankDatabaseModel>(GET_BANKS);
            return _mapper.Map<IEnumerable<Bank>>(banks);
        }

        private async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null)
        {
            using var connectionClient = _connection.GetMySqlConnection();
            return await connectionClient.QueryAsync<T>(new CommandDefinition(sql, parameters));
        }
    }
}
