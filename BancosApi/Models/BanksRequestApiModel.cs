namespace BancosApi.Models
{
    public class BanksRequestApiModel
    {
        public int Id { get; set; }
        public string Document { get; set; } = string.Empty;
        public string LongName { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string? Network { get; set; }
        public string? Website { get; set; }
        public string? Products { get; set; }
        public DateTime? DateOperationStarted { get; set; }
        public DateTime? DatePixStarted { get; set; }
    }
}
