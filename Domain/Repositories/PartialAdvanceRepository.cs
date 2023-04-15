using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IPartialAdvanceRepository
    {
        List<PartialAdvance> GetAll();
        PartialAdvance Find(int id);
        PartialAdvance CreatePartialAdvance(PartialAdvanceDto PartialAdvanceDto);
        List<PartialAdvance> GetPartialAdvanceByEmpId(string EmpId);
        PartialAdvanceDto ToPartialAdvanceDto(PartialAdvance PartialAdvance);
        PartialAdvance GetPartialAdvance(int id);
        List<PartialAdvance> GetPartialAdvanceByName(string Name);
    }

    public class PartialAdvanceRepository : IPartialAdvanceRepository
    {
        private readonly AppDbContext _context;
        public PartialAdvanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<PartialAdvance> GetAll()
        {
            return _context.PartialAdvances.ToList();
        }

        public PartialAdvance Find(int id)
        {
            return _context.PartialAdvances.Find(id);
        }

        public PartialAdvance CreatePartialAdvance(PartialAdvanceDto PartialAdvanceDto)
        {   
            var PartialAdvance = ToPartialAdvance(PartialAdvanceDto);
            _context.PartialAdvances.Add(PartialAdvance);
            this._context.SaveChanges();
            return PartialAdvance;
        }

        private PartialAdvance ToPartialAdvance(PartialAdvanceDto PartialAdvanceDto)
        {
            return new PartialAdvance
            {   

                Id= PartialAdvanceDto.Id,
                EmpId= PartialAdvanceDto.EmpId,
                EmpName= PartialAdvanceDto.EmpName,
                Period = PartialAdvanceDto.Period,
                Amount = PartialAdvanceDto.Amount,
                PeriodLeft = PartialAdvanceDto.PeriodLeft,
                PeriodTotal = PartialAdvanceDto.PeriodTotal,
                
            };
        }

        public PartialAdvanceDto ToPartialAdvanceDto(PartialAdvance PartialAdvance)
        {
            return new PartialAdvanceDto
            {
                Id= PartialAdvance.Id,
                EmpId= PartialAdvance.EmpId,
                EmpName= PartialAdvance.EmpName,
                Period = PartialAdvance.Period,
                Amount = PartialAdvance.Amount,
                PeriodLeft = PartialAdvance.PeriodLeft,
                PeriodTotal = PartialAdvance.PeriodTotal,
            };
        }
         public List<PartialAdvance> GetPartialAdvanceByName(string Name)
        {
        
            return _context.PartialAdvances.Where(x =>
                x.EmpName==(Name)).ToList();

        }
        public List<PartialAdvance> GetPartialAdvanceByEmpId(string EmpId)
        {
        
            return _context.PartialAdvances.Where(x =>
                x.EmpId==(EmpId)).ToList();

        }
          public PartialAdvance GetPartialAdvance(int id)
        {
            return _context.PartialAdvances.Find(id);
        }
         public List<PartialAdvance> GetALL()
        {
            return _context.PartialAdvances.ToList();
        }
    }
}