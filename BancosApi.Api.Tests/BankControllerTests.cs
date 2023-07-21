using Xunit;
using Moq;
using BancosApi.Controllers;
using BancosApi.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using BancosApi.Domain.Entities;

namespace BancosApi.Api.Tests
{
    public class BankControllerTests
    {
        [Fact]
        public void GetAllBanks_Ok()
        {
            var banksMockList = new List<Bank>()
            {
                new Bank(1, "123456", "Banco do Brasil", "BB", "network", "website", "products", null, null),
                new Bank(2, "123457", "Bradesco S.A.", "Bradesco", "network", "website", "products", null, null),
                new Bank(3, "123458", "Nu Pagamentos S.A.", "Nubank", "network", "website", "products", null, null),
            };

            var logger = new Mock<ILogger<BanksController>>();
            var repository = new Mock<IBanksRepository>();
            var controller = new BanksController(logger.Object, repository.Object);

            repository.Setup(repo => repo.GetBanks()).Returns(banksMockList);

            var banks = controller.GetAll();

            Assert.True(banks.StatusCode.HasValue);
            Assert.Equal(200, banks.StatusCode.Value);
            Assert.NotNull(banks.Value);
        }

        [Fact]
        public void GetBank_Ok()
        {
            int id = 1;
            var bankMock = new Bank(id, "12345", "Banco Teste", "BT", "network", "website", "products", null, null);

            var logger = new Mock<ILogger<BanksController>>();
            var repository = new Mock<IBanksRepository>();
            var controller = new BanksController(logger.Object, repository.Object);

            repository.Setup(repo => repo.GetBank(id)).Returns(bankMock);

            var bank = controller.Get(id);
            Assert.True(bank.StatusCode.HasValue);
            Assert.Equal(200, bank.StatusCode.Value);
            Assert.NotNull(bank.Value);
        }
    }
}