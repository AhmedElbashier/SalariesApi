using SalariesApi.Domain.Helpers;

namespace SalariesApi.Domain.Models.Settings
{
    public class PersonalIncomeTax
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}