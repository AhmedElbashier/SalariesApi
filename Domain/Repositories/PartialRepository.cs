using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IPartialRepository
    {
        List<Partial> GetAll();
        Partial Find(int id);
        Partial CreatePartial(PartialDto PartialDto);
        PartialDto ToPartialDto(Partial Partial);
        Partial GetPartial(int id);
        List<Partial> GetPartialByName(string Name);

    }

    public class PartialRepository : IPartialRepository
    {
        private readonly AppDbContext _context;
        public PartialRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Partial> GetAll()
        {
            return _context.Partials.ToList();
        }

        public Partial Find(int id)
        {
            return _context.Partials.Find(id);
        }

        public Partial CreatePartial(PartialDto PartialDto)
        {   
            var Partial = ToPartial(PartialDto);
            _context.Partials.Add(Partial);
            this._context.SaveChanges();
            return Partial;
        }

        private Partial ToPartial(PartialDto PartialDto)
        {
            return new Partial
            {   

                Name= PartialDto.Name,
                Exp = PartialDto.Exp,
                DegreeRoller = PartialDto.DegreeRoller,
                AcademicAllowance = PartialDto.AcademicAllowance,
                AdministrativeAssignment = PartialDto.AdministrativeAssignment,
                ContractValue = PartialDto.ContractValue,
                PrimarySalary = PartialDto.PrimarySalary,
                Department = PartialDto.Department,
                Program = PartialDto.Program,
                
            };
        }

        public PartialDto ToPartialDto(Partial Partial)
        {
            return new PartialDto
            {
                Id= Partial.Id,
                Name= Partial.Name,
                 Exp = Partial.Exp,
                DegreeRoller = Partial.DegreeRoller,
                AcademicAllowance = Partial.AcademicAllowance,
                AdministrativeAssignment = Partial.AdministrativeAssignment,
                ContractValue = Partial.ContractValue,
                PrimarySalary = Partial.PrimarySalary,
                Department = Partial.Department,
                Program = Partial.Program,
            };
        }
        
         public List<Partial> GetPartialByName(string Name)
        {
        
            return _context.Partials.Where(x =>
                x.Name==(Name)).ToList();

        }
          public Partial GetPartial(int id)
        {
            return _context.Partials.Find(id);
        }
         public List<Partial> GetALL()
        {
            return _context.Partials.ToList();
        }
    }
}