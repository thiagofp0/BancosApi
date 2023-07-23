namespace BancosApi.Infrastructure.Models
{
    public class BankDatabaseModel
    {
        public string Compe { get; set; } = string.Empty;
        public string Ispb { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string LongName { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string Network { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string PixType { get; set; } = string.Empty;
        public string Charge { get; set; } = string.Empty;
        public string CreditDocument { get; set; } = string.Empty;
        public string SalaryPortability { get; set; } = string.Empty;
        public string Products { get; set; } = string.Empty;
        public string? Url { get; set; } = string.Empty;
        public DateTime? DateOperationStarted { get; set; } = null;
        public DateTime? DatePixStarted { get; set; } = null;
        public DateTime? DateRegistred { get; set; } = null;
        public DateTime? DateUpdated { get; set; } = null;
    }
}
