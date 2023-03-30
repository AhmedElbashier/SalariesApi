using SalariesApi.Domain.Helpers;

namespace SalariesApi.Domain.Models.Settings
{
    public class Partial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Exp { get; set; }
        public string AcademicAllowance { get; set; }
        public string AdministrativeAssignment { get; set; }
        public string DegreeRoller { get; set; }
        public string ContractValue { get; set; }
        public string PrimarySalary { get; set; }
        public string Program { get; set; }
        public string Department { get; set; }
    }
}