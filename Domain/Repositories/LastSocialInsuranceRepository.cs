using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface ILastSocialInsuranceRepository
    {
        List<LastSocialInsurance> GetAll();
        LastSocialInsurance Find(int id);
        LastSocialInsurance CreateLastSocialInsurance(LastSocialInsuranceDto LastSocialInsuranceDto);
        LastSocialInsuranceDto ToLastSocialInsuranceDto(LastSocialInsurance LastSocialInsurance);
        LastSocialInsurance GetLastSocialInsurance(int id);
        List<LastSocialInsurance> GetLastSocialInsuranceByName(string Name);


    }

    public class LastSocialInsuranceRepository : ILastSocialInsuranceRepository
    {
        private readonly AppDbContext _context;
        public LastSocialInsuranceRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<LastSocialInsurance> GetAll()
        {
            return _context.LastSocialInsurances.ToList();
        }

        public LastSocialInsurance Find(int id)
        {
            return _context.LastSocialInsurances.Find(id);
        }

        public LastSocialInsurance CreateLastSocialInsurance(LastSocialInsuranceDto LastSocialInsuranceDto)
        {   
            var LastSocialInsurance = ToLastSocialInsurance(LastSocialInsuranceDto);
            _context.LastSocialInsurances.Add(LastSocialInsurance);
            this._context.SaveChanges();
            return LastSocialInsurance;
        }

        private LastSocialInsurance ToLastSocialInsurance(LastSocialInsuranceDto LastSocialInsuranceDto)
        {
            return new LastSocialInsurance
            {   

                Name= LastSocialInsuranceDto.Name,
                Value = LastSocialInsuranceDto.Value,
                
            };
        }

        public LastSocialInsuranceDto ToLastSocialInsuranceDto(LastSocialInsurance LastSocialInsurance)
        {
            return new LastSocialInsuranceDto
            {
                Id= LastSocialInsurance.Id,
                Name= LastSocialInsurance.Name,
                Value = LastSocialInsurance.Value,
            };
        }
         public List<LastSocialInsurance> GetLastSocialInsuranceByName(string Name)
        {
        
            return _context.LastSocialInsurances.Where(x =>
                x.Name==(Name)).ToList();

        }
          public LastSocialInsurance GetLastSocialInsurance(int id)
        {
            return _context.LastSocialInsurances.Find(id);
        }
         public List<LastSocialInsurance> GetALL()
        {
            return _context.LastSocialInsurances.ToList();
        }
    }
}