using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface ITaxAllowanceRepository
    {
        List<TaxAllowance> GetAll();
        TaxAllowance Find(int id);
        TaxAllowance CreateTaxAllowance(TaxAllowanceDto TaxAllowanceDto);
        TaxAllowanceDto ToTaxAllowanceDto(TaxAllowance TaxAllowance);
        TaxAllowance GetTaxAllowance(int id);
        List<TaxAllowance> GetTaxAllowanceByName(string Name);


    }

    public class TaxAllowanceRepository : ITaxAllowanceRepository
    {
        private readonly AppDbContext _context;
        public TaxAllowanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<TaxAllowance> GetAll()
        {
            return _context.TaxAllowances.ToList();
        }

        public TaxAllowance Find(int id)
        {
            return _context.TaxAllowances.Find(id);
        }

        public TaxAllowance CreateTaxAllowance(TaxAllowanceDto TaxAllowanceDto)
        {   
            var TaxAllowance = ToTaxAllowance(TaxAllowanceDto);
            _context.TaxAllowances.Add(TaxAllowance);
            this._context.SaveChanges();
            return TaxAllowance;
        }

        private TaxAllowance ToTaxAllowance(TaxAllowanceDto TaxAllowanceDto)
        {
            return new TaxAllowance
            {   

                Name= TaxAllowanceDto.Name,
                Value = TaxAllowanceDto.Value,
                
            };
        }

        public TaxAllowanceDto ToTaxAllowanceDto(TaxAllowance TaxAllowance)
        {
            return new TaxAllowanceDto
            {
                Id= TaxAllowance.Id,
                Name= TaxAllowance.Name,
                Value = TaxAllowance.Value,
            };
        }
         public List<TaxAllowance> GetTaxAllowanceByName(string Name)
        {
        
            return _context.TaxAllowances.Where(x =>
                x.Name==(Name)).ToList();

        }
          public TaxAllowance GetTaxAllowance(int id)
        {
            return _context.TaxAllowances.Find(id);
        }
         public List<TaxAllowance> GetALL()
        {
            return _context.TaxAllowances.ToList();
        }
    }
}