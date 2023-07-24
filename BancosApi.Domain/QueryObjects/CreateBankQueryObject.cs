using BancosApi.Domain.Base.Models;
using BancosApi.Domain.Entities;

namespace BancosApi.Domain.QueryObjects
{
    public class CreateBankQueryObject : Validatable
    {
        public string Id { get; private set; }
        public string Document { get; private set; }
        public string LongName { get; private set; }
        public string ShortName { get; private set; }
        public string? Network { get; private set; }
        public string? Website { get; private set; }
        public List<Product>? Products { get; private set; }
        public DateTime? DateOperationStarted { get; private set; }
        public DateTime? DatePixStarted { get; private set; }

        public CreateBankQueryObject(int id, string document, string longName, string shortName, string? network, string? website, string? products = null, DateTime? dateOperationStarted = null, DateTime? datePixStarted = null)
        {
            if (id <= 0)
                AddNotification("Id must be higher than 0.");
            if (string.IsNullOrEmpty(document))
                AddNotification("Document can't be null.");
            if (string.IsNullOrEmpty(longName))
                AddNotification("Long name can't be null.");
            if (string.IsNullOrEmpty(shortName))
                AddNotification("Short name can't be null.");
            Validate();

            string idString = string.Format("{0:000}", id);
            List<Product>? productsList = products?.Split(',').Select(product => new Product(product)).ToList();

            Id = idString;
            Document = document;
            LongName = longName;
            ShortName = shortName;
            Network = network;
            Website = website;
            Products = productsList;
            DateOperationStarted = dateOperationStarted;
            DatePixStarted = datePixStarted;
        }
    }
}
