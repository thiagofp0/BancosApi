namespace BancosApi.Domain.Entities
{
    public class Bank
    {
        public long Id { get; set; }
        public string Document { get; set; } = String.Empty;
        public string LongName { get; set; } = String.Empty;
        public string ShortName { get; set; } = String.Empty;
        public string? Network { get; set; } = String.Empty;
        public string? Website { get; set; } = String.Empty;
        public List<Product>? Products { get; set; } = new();
        public DateTime? DateOperationStarted { get; set; }
        public DateTime? DatePixStarted { get; set; }

        public Bank(long id, string document, string longName, string shortName)
        {
            if(id <= 0)
                throw new ArgumentOutOfRangeException("Id must be higher than 0.");

            if (document == null || String.IsNullOrEmpty(document))
                throw new ArgumentNullException("Document can't be null.");

            if (longName == null || String.IsNullOrEmpty(longName))
                throw new ArgumentNullException("Long name can't be null.");

            if (shortName == null || String.IsNullOrEmpty(shortName))
                throw new ArgumentNullException("Short name can't be null.");
        }
    }
}
