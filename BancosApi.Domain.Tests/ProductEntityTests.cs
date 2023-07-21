using BancosApi.Domain.Entities;
using Xunit;

namespace BancosApi.Domain.Tests
{
    public class ProductEntityTests
    {
        [Fact]
        public void CreateNewProductObject_AllValid()
        {
            var product = new Product("Teste");

            Assert.NotNull(product);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CreateNewProductObject_Invalid(string name)
        {
            Assert.ThrowsAny<Exception>(() => new Product(name));
        }
    }
}
