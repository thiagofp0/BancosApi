using BancosApi.Domain.Entities;

namespace BancosApi.Infrastructure.Models
{
    public class BankApiModel
    {
        public string Document { get; set; } = String.Empty;
        public string LongName { get; set; } = String.Empty;
        public string ShortName { get; set; } = String.Empty;
        public string Network { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public string PixType { get; set; } = String.Empty;
        public string Charge { get; set; } = String.Empty;
        public string CreditDocument { get; set; } = String.Empty;
        public string SalaryPortability { get; set; } = String.Empty;
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
        public string? Url { get; set; } = String.Empty;
        public DateTime? DateOperationStarted { get; set; } = null;
        public DateTime? DatePixStarted { get; set; } = null;
        public DateTime? DateRegistred { get; set; } = null;
        public DateTime? DateUpdated { get; set; } = null;
    }
}
