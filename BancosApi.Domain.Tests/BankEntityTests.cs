using Xunit;
using BancosApi.Domain.Entities;

namespace BancosApi.Domain.Tests
{
    public class BankEntityTests
    {
        [Theory]
        [InlineData(1, "12345678910", "Banco Teste", "Teste", "network", "website", "products", null, null)]
        public void CreateNewBankObject_AllValid(long id, string document, string longName, string shortName, string network, string website, string products, DateTime? dateOperationStarted, DateTime? datePixStarted)
        {
            var bank = new Bank(id, document, longName, shortName, network, website, products, dateOperationStarted, datePixStarted);

            Assert.NotNull(bank);
            Assert.Equal(bank.Id, id);
        }

        [Theory]
        [InlineData(0, "12345678910", "Banco Teste", "Teste", "Teste", "Teste", "Teste")]
        [InlineData(-1, "12345678910", "Banco Teste", "Teste", "Teste", "Teste", "Teste")]
        [InlineData(1, "", "Banco Teste", "Teste", "Teste", "Teste", "Teste")]
        [InlineData(1, null, "Banco Teste", "Teste", "Teste", "Teste", "Teste")]
        [InlineData(1, "12345678910", "", "Teste", "Teste", "Teste", "Teste")]
        [InlineData(1, "12345678910", null, "Teste", "Teste", "Teste", "Teste")]
        [InlineData(1, "12345678910", "Banco Teste", "", "Teste", "Teste", "Teste")]
        [InlineData(1, "12345678910", "Banco Teste", null, "Teste", "Teste", "Teste")]
        [InlineData(0, null, null, null, null, null, null)]
        public void CreateNewBankObject_Invalid(long id, string document, string longName, string shortName, string network, string website, string products)
        {
            Assert.ThrowsAny<Exception>(() => new Bank(id, document, longName, shortName, network, website, products, null, null));
        }
    }
}