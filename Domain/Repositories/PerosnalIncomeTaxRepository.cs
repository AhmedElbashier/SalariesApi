using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IPersonalIncomeTaxRepository
    {
        List<PersonalIncomeTax> GetAll();
        PersonalIncomeTax Find(int id);
        PersonalIncomeTax CreatePersonalIncomeTax(PersonalIncomeTaxDto PersonalIncomeTaxDto);
        PersonalIncomeTaxDto ToPersonalIncomeTaxDto(PersonalIncomeTax PersonalIncomeTax);
        PersonalIncomeTax GetPersonalIncomeTax(int id);
        List<PersonalIncomeTax> GetPersonalIncomeTaxByName(string Name);


    }

    public class PersonalIncomeTaxRepository : IPersonalIncomeTaxRepository
    {
        private readonly AppDbContext _context;
        public PersonalIncomeTaxRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<PersonalIncomeTax> GetAll()
        {
            return _context.PersonalIncomeTaxes.ToList();
        }

        public PersonalIncomeTax Find(int id)
        {
            return _context.PersonalIncomeTaxes.Find(id);
        }

        public PersonalIncomeTax CreatePersonalIncomeTax(PersonalIncomeTaxDto PersonalIncomeTaxDto)
        {   
            var PersonalIncomeTax = ToPersonalIncomeTax(PersonalIncomeTaxDto);
            _context.PersonalIncomeTaxes.Add(PersonalIncomeTax);
            this._context.SaveChanges();
            return PersonalIncomeTax;
        }

        private PersonalIncomeTax ToPersonalIncomeTax(PersonalIncomeTaxDto PersonalIncomeTaxDto)
        {
            return new PersonalIncomeTax
            {   

                Name= PersonalIncomeTaxDto.Name,
                Value = PersonalIncomeTaxDto.Value,
                
            };
        }

        public PersonalIncomeTaxDto ToPersonalIncomeTaxDto(PersonalIncomeTax PersonalIncomeTax)
        {
            return new PersonalIncomeTaxDto
            {
                Id= PersonalIncomeTax.Id,
                Name= PersonalIncomeTax.Name,
                Value = PersonalIncomeTax.Value,
            };
        }
         public List<PersonalIncomeTax> GetPersonalIncomeTaxByName(string Name)
        {
        
            return _context.PersonalIncomeTaxes.Where(x =>
                x.Value==(Name)).ToList();

        }
          public PersonalIncomeTax GetPersonalIncomeTax(int id)
        {
            return _context.PersonalIncomeTaxes.Find(id);
        }
         public List<PersonalIncomeTax> GetALL()
        {
            return _context.PersonalIncomeTaxes.ToList();
        }
    }
}