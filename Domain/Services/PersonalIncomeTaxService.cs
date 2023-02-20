using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IPersonalIncomeTaxService
    {
        PersonalIncomeTax GetPersonalIncomeTax(int id);
        List<PersonalIncomeTaxDto> GetALl();
        PersonalIncomeTax CreatePersonalIncomeTax(PersonalIncomeTaxDto PersonalIncomeTaxDto);
        List<PersonalIncomeTax> GetPersonalIncomeTaxByName(string Name);

    }
    public class PersonalIncomeTaxService : IPersonalIncomeTaxService
    {
        private readonly IPersonalIncomeTaxRepository _PersonalIncomeTaxRepository;

        public PersonalIncomeTaxService(IPersonalIncomeTaxRepository PersonalIncomeTaxRepository)
        {
            _PersonalIncomeTaxRepository = PersonalIncomeTaxRepository;    
        }
        
       
        public PersonalIncomeTax GetPersonalIncomeTax(int id)
        {
            return _PersonalIncomeTaxRepository.GetPersonalIncomeTax(id);
        }

        public List<PersonalIncomeTax> GetPersonalIncomeTaxByName(string Name)
        {
            return _PersonalIncomeTaxRepository.GetPersonalIncomeTaxByName(Name);
        }

        public PersonalIncomeTax CreatePersonalIncomeTax(PersonalIncomeTaxDto PersonalIncomeTaxDto)
        {
            return _PersonalIncomeTaxRepository.CreatePersonalIncomeTax(PersonalIncomeTaxDto);
        }
        public List<PersonalIncomeTaxDto> GetALl()
        {
            return _PersonalIncomeTaxRepository.GetAll().Select(_PersonalIncomeTaxRepository.ToPersonalIncomeTaxDto).ToList();
        }

    }
}