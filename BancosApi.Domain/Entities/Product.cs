namespace BancosApi.Domain.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Product(long id, string name)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be higher than 0");

            if (name == null || string.IsNullOrEmpty(name))
                throw new ArgumentException("Product name can't be null");

            Id = id;
            Name = name;
        }

    }
}
