using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IAdvanceRepository
    {
        List<Advance> GetAll();
        Advance Find(int id);
        Advance CreateAdvance(AdvanceDto AdvanceDto);
        List<Advance> GetAdvanceByEmpId(string EmpId);
        AdvanceDto ToAdvanceDto(Advance Advance);
        Advance GetAdvance(int id);
        List<Advance> GetAdvanceByName(string Name);
    }

    public class AdvanceRepository : IAdvanceRepository
    {
        private readonly AppDbContext _context;
        public AdvanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Advance> GetAll()
        {
            return _context.Advances.ToList();
        }

        public Advance Find(int id)
        {
            return _context.Advances.Find(id);
        }

        public Advance CreateAdvance(AdvanceDto AdvanceDto)
        {   
            var Advance = ToAdvance(AdvanceDto);
            _context.Advances.Add(Advance);
            this._context.SaveChanges();
            return Advance;
        }

        private Advance ToAdvance(AdvanceDto AdvanceDto)
        {
            return new Advance
            {   

                Id= AdvanceDto.Id,
                EmpId= AdvanceDto.EmpId,
                EmpName= AdvanceDto.EmpName,
                Period = AdvanceDto.Period,
                Amount = AdvanceDto.Amount,
                PeriodLeft = AdvanceDto.PeriodLeft,
                
            };
        }

        public AdvanceDto ToAdvanceDto(Advance Advance)
        {
            return new AdvanceDto
            {
                Id= Advance.Id,
                EmpId= Advance.EmpId,
                EmpName= Advance.EmpName,
                Period = Advance.Period,
                Amount = Advance.Amount,
                PeriodLeft = Advance.PeriodLeft,
            };
        }
         public List<Advance> GetAdvanceByName(string Name)
        {
        
            return _context.Advances.Where(x =>
                x.EmpName==(Name)).ToList();

        }
        public List<Advance> GetAdvanceByEmpId(string EmpId)
        {
        
            return _context.Advances.Where(x =>
                x.EmpId==(EmpId)).ToList();

        }
          public Advance GetAdvance(int id)
        {
            return _context.Advances.Find(id);
        }
         public List<Advance> GetALL()
        {
            return _context.Advances.ToList();
        }
    }
}