using SalariesApi.Domain.Helpers;

namespace SalariesApi.Domain.Models.Settings
{
    public class Advance
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string Period { get; set; }
        public string Amount { get; set; }
        public string PeriodLeft { get; set; }
    }
}