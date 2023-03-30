using SalariesApi.Domain.Helpers;

namespace SalariesApi.Domain.Models.Settings
{
    public class Absence
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string Name { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Hours { get; set; }
    }
}