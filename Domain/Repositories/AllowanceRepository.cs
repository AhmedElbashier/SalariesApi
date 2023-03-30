using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IAllowanceRepository
    {
        List<Allowance> GetAll();
        Allowance Find(int id);
        Allowance CreateAllowance(AllowanceDto AllowanceDto);
        AllowanceDto ToAllowanceDto(Allowance Allowance);
        Allowance GetAllowance(int id);
        List<Allowance> GetAllowanceByName(string Name);


    }

    public class AllowanceRepository : IAllowanceRepository
    {
        private readonly AppDbContext _context;
        public AllowanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Allowance> GetAll()
        {
            return _context.Allowances.ToList();
        }

        public Allowance Find(int id)
        {
            return _context.Allowances.Find(id);
        }

        public Allowance CreateAllowance(AllowanceDto AllowanceDto)
        {   
            var Allowance = ToAllowance(AllowanceDto);
            _context.Allowances.Add(Allowance);
            this._context.SaveChanges();
            return Allowance;
        }

        private Allowance ToAllowance(AllowanceDto AllowanceDto)
        {
            return new Allowance
            {   

                Name= AllowanceDto.Name,
                Percentage = AllowanceDto.Percentage
                
            };
        }

        public AllowanceDto ToAllowanceDto(Allowance Allowance)
        {
            return new AllowanceDto
            {
                Id= Allowance.Id,
                Name= Allowance.Name,
                Percentage = Allowance.Percentage
            };
        }
         public List<Allowance> GetAllowanceByName(string Name)
        {
        
            return _context.Allowances.Where(x =>
                x.Name==(Name)).ToList();

        }
          public Allowance GetAllowance(int id)
        {
            return _context.Allowances.Find(id);
        }
         public List<Allowance> GetALL()
        {
            return _context.Allowances.ToList();
        }
    }
}