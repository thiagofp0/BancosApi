namespace BancosApi.Domain.Entities
{
    public class Product
    {
        public string Name { get; set; }

        public Product(string name)
        {
            if (name == null || string.IsNullOrEmpty(name))
                throw new ArgumentException("Product name can't be null");

            Name = name;
        }

    }
}
