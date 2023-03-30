using SalariesApi.Domain.Helpers;

namespace SalariesApi.Domain.Models.Settings
{
    public class Allowance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Percentage { get; set; }
    }
}