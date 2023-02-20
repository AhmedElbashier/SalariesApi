using SalariesApi.Domain.Helpers;

namespace SalariesApi.Domain.Models.Settings
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Exp { get; set; }
        public string InternalExp { get; set; }
        public string FIB {get; set;}
        public string BOK {get; set;}
        public string Dept {get; set;}
        public string RecuirtDate {get; set;}
        public string NationalId {get; set;}
        public string Type {get; set;}
        public string Tt {get; set;}
        public string Rate {get; set;}
    }
}