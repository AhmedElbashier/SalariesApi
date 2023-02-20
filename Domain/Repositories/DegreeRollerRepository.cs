using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IDegreeRollerRepository
    {
        List<DegreeRoller> GetAll();
        DegreeRoller Find(int id);
        DegreeRoller CreateDegreeRoller(DegreeRollerDto DegreeRollerDto);
        DegreeRollerDto ToDegreeRollerDto(DegreeRoller DegreeRoller);
        DegreeRoller GetDegreeRoller(int id);
        List<DegreeRoller> GetDegreeRollerByName(string Name);
        List<DegreeRoller> GetDegreeRollerByNameAndExp(string DegreeRollerName, string DegreeRollerExp,string DegreeRollerEmpType);


    }

    public class DegreeRollerRepository : IDegreeRollerRepository
    {
        private readonly AppDbContext _context;
        public DegreeRollerRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<DegreeRoller> GetAll()
        {
            return _context.DegreeRollers.ToList();
        }

        public DegreeRoller Find(int id)
        {
            return _context.DegreeRollers.Find(id);
        }

        public DegreeRoller CreateDegreeRoller(DegreeRollerDto DegreeRollerDto)
        {   
            var DegreeRoller = ToDegreeRoller(DegreeRollerDto);
            _context.DegreeRollers.Add(DegreeRoller);
            this._context.SaveChanges();
            return DegreeRoller;
        }

        private DegreeRoller ToDegreeRoller(DegreeRollerDto DegreeRollerDto)
        {
            return new DegreeRoller
            {   

                Name= DegreeRollerDto.Name,
                Value = DegreeRollerDto.Value,
                PrimarySalary = DegreeRollerDto.PrimarySalary,
                Exp = DegreeRollerDto.Exp,
                EmpType = DegreeRollerDto.EmpType,
                
            };
        }

        public DegreeRollerDto ToDegreeRollerDto(DegreeRoller DegreeRoller)
        {
            return new DegreeRollerDto
            {
                Id= DegreeRoller.Id,
                Name= DegreeRoller.Name,
                Value = DegreeRoller.Value,
                PrimarySalary = DegreeRoller.PrimarySalary,
                Exp = DegreeRoller.Exp,
                EmpType = DegreeRoller.EmpType,

            };
        }
         public List<DegreeRoller> GetDegreeRollerByName(string Name)
        {
        
            return _context.DegreeRollers.Where(x =>
                x.Value==(Name)).ToList();

        }
         public List<DegreeRoller> GetDegreeRollerByNameAndExp(string DegreeRollerName, string DegreeRollerExp,string DegreeRollerEmpType)
        {
        
            return _context.DegreeRollers.Where(x =>
                x.Name==(DegreeRollerName)&& x.Exp == DegreeRollerExp && x.EmpType== DegreeRollerEmpType ).ToList();

        }
          public DegreeRoller GetDegreeRoller(int id)
        {
            return _context.DegreeRollers.Find(id);
        }
         public List<DegreeRoller> GetALL()
        {
            return _context.DegreeRollers.ToList();
        }
    }
}