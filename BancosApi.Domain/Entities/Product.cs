using BancosApi.Domain.Base.Models;

namespace BancosApi.Domain.Entities
{
    public class Product : Validatable
    {
        public string Name { get; private set; } = string.Empty;

        public Product(string name)
        {
            if (name == null || string.IsNullOrEmpty(name))
                AddNotification("Product name can't be null");
            
            Validate();
            
            Name = name;
        }

    }
}
