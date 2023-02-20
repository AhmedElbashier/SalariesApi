using SalariesApi.Domain.Helpers;

namespace SalariesApi.Domain.Models.Settings
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Program { get; set; }
        public string Sylbus { get; set; }
        public string Semester { get; set; }
        public string Period { get; set; }
        public string FirstMonth { get; set; }
        public string SecondMonth { get; set; }
        public string ThirdMonth { get; set; }
         public string FirstMonthPayRoll { get; set; }
        public string SecondMonthPayRoll { get; set; }
        public string ThirdMonthPayRoll { get; set; }
        public string Amount { get; set; }
    }
}