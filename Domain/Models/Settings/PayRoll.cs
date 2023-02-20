using SalariesApi.Domain.Helpers;

namespace SalariesApi.Domain.Models.Settings
{
    public class PayRoll
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpId { get; set; }
        public string Year { get; set; }
        public string Month {get; set;}
        public string DegreeRoller {get; set;}
        public string PrimarySalary {get; set;}
        public string FirstInsurance {get; set;}
        public string LastInsurance {get; set;}
        public string StampBase {get; set;}
        public string TheBaseSubjectTax {get; set;}
        public string PersonalTax { get; set; }
        public string NetBaseSalary { get; set; }
        public string VariableTax { get; set; }
        public string TaxOnVariableAllowanceResult { get; set; }
        public string NetBaseVariableAllowance {get; set;}
        public string FinalNetSalary {get; set;}
        public string FinalNetSalaryBeforeDiscount {get; set;}
        public string FinalSalaryDeduction {get; set;}
        public string FinalSalaryAfterDeduction {get; set;}
        public string TaxTotal {get; set;}
        public string EmployeeCost {get; set;}
        public string StartingSalary { get; set; }
        public string LivingExpense {get; set;}
        public string HousingExpense {get; set;}
        public string DeportationExpense {get; set;}
        public string EmpType {get; set;}
        public string Valid {get; set;}
    }
}