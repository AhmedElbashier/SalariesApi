using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IPartialPayRollRepository
    {
        List<PartialPayRoll> GetAll();
        PartialPayRoll Find(int id);
        PartialPayRoll CreatePartialPayRoll(PartialPayRollDto PartialPayRollDto);
        PartialPayRollDto ToPartialPayRollDto(PartialPayRoll PartialPayRoll);
        PartialPayRoll GetPartialPayRoll(int id);
        List<PartialPayRoll> GetPartialPayRollByName(string Name);
        List<PartialPayRoll> GetPartialPayRollByIdAndMonthYear(string EmpId, string Month, string Year);

    }

    public class PartialPayRollRepository : IPartialPayRollRepository
    {
        private readonly AppDbContext _context;
        public PartialPayRollRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<PartialPayRoll> GetAll()
        {
            return _context.PartialPayRolls.ToList();
        }

        public PartialPayRoll Find(int id)
        {
            return _context.PartialPayRolls.Find(id);
        }

        public PartialPayRoll CreatePartialPayRoll(PartialPayRollDto PartialPayRollDto)
        {   
            var PartialPayRoll = ToPartialPayRoll(PartialPayRollDto);
            _context.PartialPayRolls.Add(PartialPayRoll);
            this._context.SaveChanges();
            return PartialPayRoll;
        }

        private PartialPayRoll ToPartialPayRoll(PartialPayRollDto PartialPayRollDto)
        {
            return new PartialPayRoll
            {   

                EmpName= PartialPayRollDto.EmpName,
                EmpId = PartialPayRollDto.EmpId,
                Year = PartialPayRollDto.Year,
                Month = PartialPayRollDto.Month,
                ContractValue = PartialPayRollDto.ContractValue,
                PrimarySalary= PartialPayRollDto.PrimarySalary,
                BookAndResearch= PartialPayRollDto.BookAndResearch,
                AcademicBase = PartialPayRollDto.AcademicBase,
                Stamp = PartialPayRollDto.Stamp,
                TheBaseSubjectTax = PartialPayRollDto.TheBaseSubjectTax,
                PersonalTax = PartialPayRollDto.PersonalTax,
                FinalNetSalary= PartialPayRollDto.FinalNetSalary,
                FinalNetSalaryBeforeDiscount= PartialPayRollDto.FinalNetSalaryBeforeDiscount,
                FinalSalaryDeduction = PartialPayRollDto.FinalSalaryDeduction,
                FinalSalaryAfterDeduction = PartialPayRollDto.FinalSalaryAfterDeduction,
                EmployeeCost = PartialPayRollDto.EmployeeCost,
                StartingSalary = PartialPayRollDto.StartingSalary,
                LivingExpense = PartialPayRollDto.LivingExpense,
                HousingExpense = PartialPayRollDto.HousingExpense,
                DeportationExpense = PartialPayRollDto.DeportationExpense,
                Valid = PartialPayRollDto.Valid,
                
            };
        }

        public PartialPayRollDto ToPartialPayRollDto(PartialPayRoll PartialPayRoll)
        {
            return new PartialPayRollDto
            {
                Id= PartialPayRoll.Id,
                EmpName= PartialPayRoll.EmpName,
                EmpId = PartialPayRoll.EmpId,
                Year = PartialPayRoll.Year,
                Month = PartialPayRoll.Month,
                ContractValue = PartialPayRoll.ContractValue,
                PrimarySalary= PartialPayRoll.PrimarySalary,
                BookAndResearch= PartialPayRoll.BookAndResearch,
                AcademicBase = PartialPayRoll.AcademicBase,
                Stamp = PartialPayRoll.Stamp,
                TheBaseSubjectTax = PartialPayRoll.TheBaseSubjectTax,
                PersonalTax = PartialPayRoll.PersonalTax,
                FinalNetSalary= PartialPayRoll.FinalNetSalary,
                FinalNetSalaryBeforeDiscount= PartialPayRoll.FinalNetSalaryBeforeDiscount,
                FinalSalaryDeduction = PartialPayRoll.FinalSalaryDeduction,
                FinalSalaryAfterDeduction = PartialPayRoll.FinalSalaryAfterDeduction,
                EmployeeCost = PartialPayRoll.EmployeeCost,
                StartingSalary = PartialPayRoll.StartingSalary,
                LivingExpense = PartialPayRoll.LivingExpense,
                HousingExpense = PartialPayRoll.HousingExpense,
                DeportationExpense = PartialPayRoll.DeportationExpense,
                Valid = PartialPayRoll.Valid,
            };
        }
         public List<PartialPayRoll> GetPartialPayRollByName(string Name)
        {
        
            return _context.PartialPayRolls.Where(x =>
                x.EmpName==(Name)).ToList();

        }
        public List<PartialPayRoll> GetPartialPayRollByIdAndMonthYear(string EmpId, string Month, string Year)
        {
        
            return _context.PartialPayRolls.Where(x =>
                x.EmpId==EmpId&&x.Month==Month&& x.Year==Year).ToList();

        }
          public PartialPayRoll GetPartialPayRoll(int id)
        {
            return _context.PartialPayRolls.Find(id);
        }
         public List<PartialPayRoll> GetALL()
        {
            return _context.PartialPayRolls.ToList();
        }
    }
}