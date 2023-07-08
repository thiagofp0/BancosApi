namespace BancosApi.Domain.Entities
{
    public class Bank
    {
        public int Id { get; set; }
        public string Document { get; set; } = String.Empty;
        public string LongName { get; set; } = String.Empty;
        public string ShortName { get; set; } = String.Empty;
        public string Network { get; set; } = String.Empty;
        public string Website { get; set; } = String.Empty;
        public List<Product> Products { get; set; } = new();
        public DateTime DateOperationStarted { get; set; }
        public DateTime DatePixStarted { get; set; }

    }
}
