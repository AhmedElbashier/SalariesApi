using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IFirstSocialInsuranceService
    {
        FirstSocialInsurance GetFirstSocialInsurance(int id);
        List<FirstSocialInsuranceDto> GetALl();
        FirstSocialInsurance CreateFirstSocialInsurance(FirstSocialInsuranceDto FirstSocialInsuranceDto);
        List<FirstSocialInsurance> GetFirstSocialInsuranceByName(string Name);

    }
    public class FirstSocialInsuranceService : IFirstSocialInsuranceService
    {
        private readonly IFirstSocialInsuranceRepository _FirstSocialInsuranceRepository;

        public FirstSocialInsuranceService(IFirstSocialInsuranceRepository FirstSocialInsuranceRepository)
        {
            _FirstSocialInsuranceRepository = FirstSocialInsuranceRepository;    
        }
        
       
        public FirstSocialInsurance GetFirstSocialInsurance(int id)
        {
            return _FirstSocialInsuranceRepository.GetFirstSocialInsurance(id);
        }

        public List<FirstSocialInsurance> GetFirstSocialInsuranceByName(string Name)
        {
            return _FirstSocialInsuranceRepository.GetFirstSocialInsuranceByName(Name);
        }

        public FirstSocialInsurance CreateFirstSocialInsurance(FirstSocialInsuranceDto FirstSocialInsuranceDto)
        {
            return _FirstSocialInsuranceRepository.CreateFirstSocialInsurance(FirstSocialInsuranceDto);
        }
        public List<FirstSocialInsuranceDto> GetALl()
        {
            return _FirstSocialInsuranceRepository.GetAll().Select(_FirstSocialInsuranceRepository.ToFirstSocialInsuranceDto).ToList();
        }

    }
}