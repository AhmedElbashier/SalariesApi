using SalariesApi.Domain.Helpers;

namespace SalariesApi.Domain.Models.Settings
{
    public class Role
    {
        public int Id { get; set; }
        public bool AcademicEmp { get; set; }
        public bool AdminEmp { get; set; }
        public bool AcademicPayRoll { get; set; }
        public bool AdminPayRoll { get; set; }
        public bool PackagePayRoll { get; set; }
        public bool TrainingPayRoll { get; set; }
        public bool Reports { get; set; }
        public bool Absence { get; set; }
        public bool Advance { get; set; }
        public bool Partial { get; set; }
        public bool Settings { get; set; }
    }
}