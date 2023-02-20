using SalariesApi.Domain.Helpers;

namespace SalariesApi.Domain.Models.Settings
{
    public class DegreeRoller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string PrimarySalary { get; set; }
        public string Exp { get; set; }
        public string EmpType { get; set; }

    }
}