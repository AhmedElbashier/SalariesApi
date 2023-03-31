using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Globalization;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Helpers
{

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
    public class TaxAllowanceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class StampSignDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class StampBaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class PerformanceIncentiveDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class LastSocialInsuranceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class InternalExperienceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class FirstSocialInsuranceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class DegreeRollerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string PrimarySalary { get; set; }
        public string Exp { get; set; }
        public string EmpType { get; set; }
    }
    public class BookAndSearchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class PackageDto
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
    public class PackagePayRollDto
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
    public class TrainingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Amount { get; set; }
    }
    public class TrainingPayRollDto
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
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Exp { get; set; }
        public string InternalExp { get; set; }
        public string FIB { get; set; }
        public string BOK { get; set; }
        public string Dept { get; set; }
        public string RecuirtDate { get; set; }
        public string NationalId { get; set; }
        public string Type { get; set; }
        public string Tt { get; set; }
        public string Rate {get; set;}
    }
    public class PersonalIncomeTaxDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

    }
    public class PayRollDto
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpId { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string DegreeRoller { get; set; }
        public string PrimarySalary { get; set; }
        public string FirstInsurance { get; set; }
        public string LastInsurance { get; set; }
        public string StampBase { get; set; }
        public string TheBaseSubjectTax { get; set; }
        public string PersonalTax { get; set; }
        public string NetBaseSalary { get; set; }
        public string VariableTax { get; set; }
        public string TaxOnVariableAllowanceResult { get; set; }
        public string NetBaseVariableAllowance { get; set; }
        public string FinalNetSalary { get; set; }
        public string FinalNetSalaryBeforeDiscount { get; set; }
        public string FinalSalaryDeduction { get; set; }
        public string FinalSalaryAfterDeduction { get; set; }
        public string TaxTotal { get; set; }
        public string EmployeeCost { get; set; }
        public string StartingSalary { get; set; }
        public string LivingExpense { get; set; }
        public string HousingExpense { get; set; }
        public string DeportationExpense { get; set; }
        public string EmpType { get; set; }
        public string Valid { get; set; }
        public string BookAndResearch {get; set;}

    }
    public class AbsenceDto
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string Name { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Hours { get; set; }
    }
    public class AdvanceDto
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string Period { get; set; }
        public string Amount { get; set; }
        public string PeriodLeft { get; set; }
        public string PeriodTotal { get; set; }
    }
    public class AllowanceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Percentage { get; set; }
    }
    public class RoleDto
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
    public class PartialPayRollDto
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpId { get; set; }
        public string Year { get; set; }
        public string Month {get; set;}
        public string ContractValue {get; set;}
        public string PrimarySalary {get; set;}
        public string BookAndResearch {get; set;}
        public string AcademicBase {get; set;}
        public string Stamp {get; set;}
        public string TheBaseSubjectTax {get; set;}
        public string PersonalTax { get; set; }
        public string FinalNetSalary {get; set;}
        public string FinalNetSalaryBeforeDiscount {get; set;}
        public string FinalSalaryDeduction {get; set;}
        public string FinalSalaryAfterDeduction {get; set;}
        public string EmployeeCost {get; set;}
        public string StartingSalary { get; set; }
        public string LivingExpense {get; set;}
        public string HousingExpense {get; set;}
        public string DeportationExpense {get; set;}
        public string Valid {get; set;}
    }
    public class PartialDto
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

    public class AdvanceAccountDto
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpId { get; set; }
        public string FirstMonth { get; set; }
        public string LastMonth { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
    }
}