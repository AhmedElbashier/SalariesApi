using SalariesApi.Domain.Helpers;

namespace SalariesApi.Domain.Models.Settings
{
    public class TrainingPayRoll
    {
        public int Id { get; set; }
        public string TrainingId { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Amount { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string User { get; set; }
    }
}