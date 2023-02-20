using SalariesApi.Domain.Helpers;

namespace SalariesApi.Domain.Models.Settings
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}