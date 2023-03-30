using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IAbsenceRepository
    {
        List<Absence> GetAll();
        Absence Find(int id);
        Absence CreateAbsence(AbsenceDto AbsenceDto);
        AbsenceDto ToAbsenceDto(Absence Absence);
        Absence GetAbsence(int id);
        List<Absence> GetAbsenceByName(string Name);
        List<Absence> GetAbsenceByEmpId(string EmpId);
        List<Absence> GetAbsenceByNameAndExp(string EmployeeName, string Month);


    }

    public class AbsenceRepository : IAbsenceRepository
    {
        private readonly AppDbContext _context;
        public AbsenceRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Absence> GetAll()
        {
            return _context.Absences.ToList();
        }

        public Absence Find(int id)
        {
            return _context.Absences.Find(id);
        }

        public Absence CreateAbsence(AbsenceDto AbsenceDto)
        {   
            var Absence = ToAbsence(AbsenceDto);
            _context.Absences.Add(Absence);
            this._context.SaveChanges();
            return Absence;
        }

        private Absence ToAbsence(AbsenceDto AbsenceDto)
        {
            return new Absence
            {   
                EmpId= AbsenceDto.EmpId,
                Name= AbsenceDto.Name,
                Month= AbsenceDto.Month,
                Year= AbsenceDto.Year,
                Hours= AbsenceDto.Hours,
            };
        }

        public AbsenceDto ToAbsenceDto(Absence Absence)
        {
            return new AbsenceDto
            {
                Id= Absence.Id,
                Name= Absence.Name,
                EmpId= Absence.EmpId,
                Month= Absence.Month,
                Year= Absence.Year,
                Hours= Absence.Hours,
            };
        }
         public List<Absence> GetAbsenceByName(string Name)
        {
            return _context.Absences.Where(x =>
                x.Name==(Name)).ToList();
        }
         public List<Absence> GetAbsenceByNameAndExp(string EmployeeName, string Month)
        {
        
            return _context.Absences.Where(x =>
                x.Name==(EmployeeName)&& x.Month == Month).ToList();

        }
        public List<Absence> GetAbsenceByEmpId(string EmpId)
        {
        
            return _context.Absences.Where(x =>
                x.EmpId==(EmpId)).ToList();

        }
          public Absence GetAbsence(int id)
        {
            return _context.Absences.Find(id);
        }
         public List<Absence> GetALL()
        {
            return _context.Absences.ToList();
        }
    }
}