using AutoMapper;
using BancosApi.Domain.Base.Adapters;
using BancosApi.Domain.Base.Exceptions;
using BancosApi.Domain.Entities;
using BancosApi.Domain.Interfaces;
using BancosApi.Domain.QueryObjects;
using BancosApi.Infrastructure.Models;
using Dapper;
using MySqlConnector;

namespace BancosApi.Infrastructure
{
    public class SqlRepository : IBanksRepository
    {
        private const string GET_BANKS = "SELECT * FROM Banks";
        private const string GET_BANK = "SELECT * FROM Banks WHERE Compe=@Compe";
        private const string CREATE_BANK = "INSERT INTO Banks (Compe, Document, LongName, ShortName, Network, Products, Url, DateOperationStarted, DatePixStarted) VALUES (@Compe, @Document, @LongName, @ShortName, @Network, @Products, @Url, @DateOperationStarted, @DatePixStarted);";

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
        
        public async Task<bool> CreateBank(CreateBankQueryObject createBankQueryObject)
        {
            await VerifyIfBankAlreadyExists(createBankQueryObject.Id);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Compe", createBankQueryObject.Id);
            parameters.Add("@Document", createBankQueryObject.Document);
            parameters.Add("@LongName", createBankQueryObject.LongName);
            parameters.Add("@ShortName", createBankQueryObject.ShortName);
            parameters.Add("@Network", createBankQueryObject.Network);
            parameters.Add("@Products", createBankQueryObject.Products);
            parameters.Add("@Url", createBankQueryObject.Website);
            parameters.Add("@DateOperationStarted", createBankQueryObject.DateOperationStarted);
            parameters.Add("@DatePixStarted", createBankQueryObject.DatePixStarted);
            
            var result = await QueryAsync<Bank>(CREATE_BANK, parameters);

            return result.Any();
        }

        private async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null)
        {
            using var connectionClient = _connection.GetConnection();
            return await connectionClient.QueryAsync<T>(new CommandDefinition(sql, parameters));
        }

        private async Task<bool> VerifyIfBankAlreadyExists(string id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Compe", id);
            var bank = await QueryAsync<BankDatabaseModel>(GET_BANK, parameters);
            if (bank.Any())
                throw new InvalidDomainStateException("Bank already exists.");
            return true;
        }
    }
}
