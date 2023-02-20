using SalariesApi.Domain.Helpers;

namespace SalariesApi.Domain.Models.Settings
{
    public class TaxAllowance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}