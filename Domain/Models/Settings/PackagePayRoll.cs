using SalariesApi.Domain.Helpers;

namespace SalariesApi.Domain.Models.Settings
{
    public class PackagePayRoll
    {
        public int Id { get; set; }
        public string  PackageId { get; set; }
        public string Name { get; set; }
        public string Program { get; set; }
        public string Sylbus { get; set; }
        public string Semester { get; set; }
        public string Period { get; set; }
        public string FirstMonth { get; set; }
        public string SecondMonth { get; set; }
        public string ThirdMonth { get; set; }
        public string Amount { get; set; }
        public string PayRollMonth { get; set; }
        public string PayRollYear { get; set; }
        public string Left { get; set; }
        public string User { get; set; }
        
    }
}