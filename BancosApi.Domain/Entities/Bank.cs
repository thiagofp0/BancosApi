namespace BancosApi.Domain.Entities
{
    public class Bank
    {
        public long? Id { get; set; }
        public string Document { get; private set; } = String.Empty;
        public string LongName { get; private set; } = String.Empty;
        public string ShortName { get; private set; } = String.Empty;
        public string? Network { get; private set; } = String.Empty;
        public string? Url { get; private set; } = String.Empty;
        private string? ProductsString { get; set; } = String.Empty;
        public List<Product>? Products { get => ParseProducts(ProductsString); }
        public DateTime? DateOperationStarted { get; private set; }
        public DateTime? DatePixStarted { get; private set; }

        public Bank(long id, string document, string longName, string shortName, string network, string website, string products, DateTime? dateOperationStarted, DateTime? datePixStarted)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("Id must be higher than 0.");

            if (document == null || String.IsNullOrEmpty(document))
                throw new ArgumentNullException("Document can't be null.");

            if (longName == null || String.IsNullOrEmpty(longName))
                throw new ArgumentNullException("Long name can't be null.");

            if (shortName == null || String.IsNullOrEmpty(shortName))
                throw new ArgumentNullException("Short name can't be null.");

            Id = id;
            Document = document;
            LongName = longName;
            ShortName = shortName;
            Network = network;
            Url = website;
            ProductsString = products;
            DateOperationStarted = dateOperationStarted;
            DatePixStarted = datePixStarted;
        }

        private List<Product> ParseProducts(string? products)
        {
            if (products == null || String.IsNullOrEmpty(products))
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
