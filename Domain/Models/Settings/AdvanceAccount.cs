using SalariesApi.Domain.Helpers;

namespace SalariesApi.Domain.Models.Settings
{
    public class AdvanceAccount
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpId { get; set; }
        public string FirstMonth { get; set; }
        public string LastMonth { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
    }
}