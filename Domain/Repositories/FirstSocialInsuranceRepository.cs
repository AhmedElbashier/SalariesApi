using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IFirstSocialInsuranceRepository
    {
        List<FirstSocialInsurance> GetAll();
        FirstSocialInsurance Find(int id);
        FirstSocialInsurance CreateFirstSocialInsurance(FirstSocialInsuranceDto FirstSocialInsuranceDto);
        FirstSocialInsuranceDto ToFirstSocialInsuranceDto(FirstSocialInsurance FirstSocialInsurance);
        FirstSocialInsurance GetFirstSocialInsurance(int id);
        List<FirstSocialInsurance> GetFirstSocialInsuranceByName(string Name);


    }

    public class FirstSocialInsuranceRepository : IFirstSocialInsuranceRepository
    {
        private readonly AppDbContext _context;
        public FirstSocialInsuranceRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<FirstSocialInsurance> GetAll()
        {
            return _context.FirstSocialInsurances.ToList();
        }

        public FirstSocialInsurance Find(int id)
        {
            return _context.FirstSocialInsurances.Find(id);
        }

        public FirstSocialInsurance CreateFirstSocialInsurance(FirstSocialInsuranceDto FirstSocialInsuranceDto)
        {   
            var FirstSocialInsurance = ToFirstSocialInsurance(FirstSocialInsuranceDto);
            _context.FirstSocialInsurances.Add(FirstSocialInsurance);
            this._context.SaveChanges();
            return FirstSocialInsurance;
        }

        private FirstSocialInsurance ToFirstSocialInsurance(FirstSocialInsuranceDto FirstSocialInsuranceDto)
        {
            return new FirstSocialInsurance
            {   

                Name= FirstSocialInsuranceDto.Name,
                Value = FirstSocialInsuranceDto.Value,
                
            };
        }

        public FirstSocialInsuranceDto ToFirstSocialInsuranceDto(FirstSocialInsurance FirstSocialInsurance)
        {
            return new FirstSocialInsuranceDto
            {
                Id= FirstSocialInsurance.Id,
                Name= FirstSocialInsurance.Name,
                Value = FirstSocialInsurance.Value,
            };
        }
         public List<FirstSocialInsurance> GetFirstSocialInsuranceByName(string Name)
        {
        
            return _context.FirstSocialInsurances.Where(x =>
                x.Name==(Name)).ToList();

        }
          public FirstSocialInsurance GetFirstSocialInsurance(int id)
        {
            return _context.FirstSocialInsurances.Find(id);
        }
         public List<FirstSocialInsurance> GetALL()
        {
            return _context.FirstSocialInsurances.ToList();
        }
    }
}