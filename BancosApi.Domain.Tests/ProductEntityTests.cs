using BancosApi.Domain.Entities;
using Xunit;

namespace BancosApi.Domain.Tests
{
    public class ProductEntityTests
    {
        [Fact]
        public void CreateNewProductObject_AllValid()
        {
            var product = new Product(1, "Teste");

            Assert.NotNull(product);
            Assert.Equal(1, product.Id);
        }

        [Theory]
        [InlineData(0, "Teste")]
        [InlineData(-1, "Teste")]
        [InlineData(1, "")]
        [InlineData(1, null)]
        [InlineData(0, "")]
        [InlineData(-1, null)]
        public void CreateNewProductObject_Invalid(long id, string name)
        {
            Assert.ThrowsAny<Exception>(() => new Product(id, name));
        }
    }
}
