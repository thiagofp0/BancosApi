using BancosApi.Domain.Base.Models;

namespace BancosApi.Domain.Entities
{
    public class Bank : Validatable
    {
        public long? Id { get; set; }
        public string Document { get; private set; } = string.Empty;
        public string LongName { get; private set; } = string.Empty;
        public string ShortName { get; private set; } = string.Empty;
        public string? Network { get; private set; } = string.Empty;
        public string? Url { get; private set; } = string.Empty;
        private string? ProductsString { get; set; } = string.Empty;
        public List<Product>? Products { get => ParseProducts(ProductsString); }
        public DateTime? DateOperationStarted { get; private set; }
        public DateTime? DatePixStarted { get; private set; }

        public Bank(long id, string document, string longName, string shortName, string network, string website, string products, DateTime? dateOperationStarted, DateTime? datePixStarted)
        {
            if (id <= 0)
                AddNotification("Id must be higher than 0.");

            if (document == null || string.IsNullOrEmpty(document))
                AddNotification("Document can't be null.");
            
            if (longName == null || string.IsNullOrEmpty(longName))
                AddNotification("Long name can't be null.");

            if (shortName == null || string.IsNullOrEmpty(shortName))
                AddNotification("Short name can't be null.");

            Validate();

            Id = id;
            Document = document ?? "";
            LongName = longName ?? "";
            ShortName = shortName ?? "";
            Network = network;
            Url = website;
            ProductsString = products;
            DateOperationStarted = dateOperationStarted;
            DatePixStarted = datePixStarted;
        }

        private List<Product> ParseProducts(string? products)
        {
            if (products == null || string.IsNullOrEmpty(products))
                return new List<Product>();
            
            var productsList = new List<Product>();
            var productsArray = products.Split(',');
            foreach (var productName in productsArray)
            {
                productsList.Add(new Product(productName));
            }
            return productsList;
        }
    }
}
