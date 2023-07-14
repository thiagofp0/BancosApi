using Xunit;
using BancosApi.Domain.Entities;

namespace BancosApi.Domain.Tests
{
    public class BankEntityTests
    {
        [Theory]
        [InlineData(1, "12345678910", "Banco Teste", "Teste")]
        public void CreateNewBankObject_AllValid(long id, string document, string longName, string shortName)
        {
            var bank = new Bank(id, document, longName, shortName);

            Assert.NotNull(bank);
            Assert.Equal(bank.Id, id);
        }

        [Theory]
        [InlineData(0, "12345678910", "Banco Teste", "Teste")]
        [InlineData(-1, "12345678910", "Banco Teste", "Teste")]
        [InlineData(1, "", "Banco Teste", "Teste")]
        [InlineData(1, null, "Banco Teste", "Teste")]
        [InlineData(1, "12345678910", "", "Teste")]
        [InlineData(1, "12345678910", null, "Teste")]
        [InlineData(1, "12345678910", "Banco Teste", "")]
        [InlineData(1, "12345678910", "Banco Teste", null)]
        [InlineData(0, null, null, null)]
        public void CreateNewBankObject_Invalid(long id, string document, string longName, string shortName)
        {
            Assert.ThrowsAny<Exception>(() => new Bank(id, document, longName, shortName));
        }
    }
}