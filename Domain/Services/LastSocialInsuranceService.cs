using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface ILastSocialInsuranceService
    {
        LastSocialInsurance GetLastSocialInsurance(int id);
        List<LastSocialInsuranceDto> GetALl();
        LastSocialInsurance CreateLastSocialInsurance(LastSocialInsuranceDto LastSocialInsuranceDto);
        List<LastSocialInsurance> GetLastSocialInsuranceByName(string Name);

    }
    public class LastSocialInsuranceService : ILastSocialInsuranceService
    {
        private readonly ILastSocialInsuranceRepository _LastSocialInsuranceRepository;

        public LastSocialInsuranceService(ILastSocialInsuranceRepository LastSocialInsuranceRepository)
        {
            _LastSocialInsuranceRepository = LastSocialInsuranceRepository;    
        }
        
       
        public LastSocialInsurance GetLastSocialInsurance(int id)
        {
            return _LastSocialInsuranceRepository.GetLastSocialInsurance(id);
        }

        public List<LastSocialInsurance> GetLastSocialInsuranceByName(string Name)
        {
            return _LastSocialInsuranceRepository.GetLastSocialInsuranceByName(Name);
        }

        public LastSocialInsurance CreateLastSocialInsurance(LastSocialInsuranceDto LastSocialInsuranceDto)
        {
            return _LastSocialInsuranceRepository.CreateLastSocialInsurance(LastSocialInsuranceDto);
        }
        public List<LastSocialInsuranceDto> GetALl()
        {
            return _LastSocialInsuranceRepository.GetAll().Select(_LastSocialInsuranceRepository.ToLastSocialInsuranceDto).ToList();
        }

    }
}