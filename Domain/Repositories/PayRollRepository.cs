using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IPayRollRepository
    {
        List<PayRoll> GetAll();
        PayRoll Find(int id);
        PayRoll CreatePayRoll(PayRollDto PayRollDto);
        PayRollDto ToPayRollDto(PayRoll PayRoll);
        PayRoll GetPayRoll(int id);
        List<PayRoll> GetPayRollByIdAndMonth(string EmpId, string Month);
    }

    public class PayRollRepository : IPayRollRepository
    {
        private readonly AppDbContext _context;
        public PayRollRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<PayRoll> GetAll()
        {
            return _context.PayRolls.ToList();
        }

        public PayRoll Find(int id)
        {
            return _context.PayRolls.Find(id);
        }

        public PayRoll CreatePayRoll(PayRollDto PayRollDto)
        {   
            var PayRoll = ToPayRoll(PayRollDto);
            _context.PayRolls.Add(PayRoll);
            this._context.SaveChanges();
            return PayRoll;
        }

        private PayRoll ToPayRoll(PayRollDto PayRollDto)
        {
            return new PayRoll
            {   
                EmpName= PayRollDto.EmpName,
                EmpId = PayRollDto.EmpId,
                Year = PayRollDto.Year,
                Month = PayRollDto.Month,
                DegreeRoller = PayRollDto.DegreeRoller,
                PrimarySalary = PayRollDto.PrimarySalary,
                FirstInsurance = PayRollDto.FirstInsurance,
                LastInsurance = PayRollDto.LastInsurance,
                StampBase = PayRollDto.StampBase,
                TheBaseSubjectTax = PayRollDto.TheBaseSubjectTax,
                PersonalTax = PayRollDto.PersonalTax,
                NetBaseSalary= PayRollDto.NetBaseSalary,
                VariableTax= PayRollDto.VariableTax,
                TaxOnVariableAllowanceResult = PayRollDto.TaxOnVariableAllowanceResult,
                NetBaseVariableAllowance = PayRollDto.NetBaseVariableAllowance,
                FinalNetSalary = PayRollDto.FinalNetSalary,
                FinalNetSalaryBeforeDiscount = PayRollDto.FinalNetSalaryBeforeDiscount,
                FinalSalaryDeduction = PayRollDto.FinalSalaryDeduction,
                FinalSalaryAfterDeduction = PayRollDto.FinalSalaryAfterDeduction,
                TaxTotal = PayRollDto.TaxTotal,
                EmployeeCost = PayRollDto.EmployeeCost,
                StartingSalary = PayRollDto.StartingSalary,
                LivingExpense = PayRollDto.LivingExpense,
                HousingExpense = PayRollDto.HousingExpense,
                DeportationExpense = PayRollDto.DeportationExpense,
                EmpType = PayRollDto.EmpType,
                Valid = PayRollDto.Valid,
            };
        }

        public PayRollDto ToPayRollDto(PayRoll PayRoll)
        {
            return new PayRollDto
            {
                Id= PayRoll.Id,
                EmpName= PayRoll.EmpName,
                EmpId = PayRoll.EmpId,
                Year = PayRoll.Year,
                Month = PayRoll.Month,
                DegreeRoller = PayRoll.DegreeRoller,
                PrimarySalary = PayRoll.PrimarySalary,
                FirstInsurance = PayRoll.FirstInsurance,
                LastInsurance = PayRoll.LastInsurance,
                StampBase = PayRoll.StampBase,
                TheBaseSubjectTax = PayRoll.TheBaseSubjectTax,
                PersonalTax = PayRoll.PersonalTax,
                NetBaseSalary= PayRoll.NetBaseSalary,
                VariableTax= PayRoll.VariableTax,
                TaxOnVariableAllowanceResult = PayRoll.TaxOnVariableAllowanceResult,
                NetBaseVariableAllowance = PayRoll.NetBaseVariableAllowance,
                FinalNetSalary = PayRoll.FinalNetSalary,
                FinalNetSalaryBeforeDiscount = PayRoll.FinalNetSalaryBeforeDiscount,
                FinalSalaryDeduction = PayRoll.FinalSalaryDeduction,
                FinalSalaryAfterDeduction = PayRoll.FinalSalaryAfterDeduction,
                TaxTotal = PayRoll.TaxTotal,
                EmployeeCost = PayRoll.EmployeeCost,
                StartingSalary = PayRoll.StartingSalary,
                LivingExpense = PayRoll.LivingExpense,
                HousingExpense = PayRoll.HousingExpense,
                DeportationExpense = PayRoll.DeportationExpense,
                EmpType = PayRoll.EmpType,
                Valid = PayRoll.Valid,

            };
        }
         public List<PayRoll> GetPayRollByIdAndMonth(string EmpId,string Month)
        {
        
            return _context.PayRolls.Where(x =>
                x.EmpId==EmpId&& x.Month==Month).ToList();

        }
          public PayRoll GetPayRoll(int id)
        {
            return _context.PayRolls.Find(id);
        }
         public List<PayRoll> GetALL()
        {
            return _context.PayRolls.ToList();
        }
    }
}