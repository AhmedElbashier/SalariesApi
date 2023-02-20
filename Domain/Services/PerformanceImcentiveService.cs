using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IPerformanceIncentiveService
    {
        PerformanceIncentive GetPerformanceIncentive(int id);
        List<PerformanceIncentiveDto> GetALl();
        PerformanceIncentive CreatePerformanceIncentive(PerformanceIncentiveDto PerformanceIncentiveDto);
        List<PerformanceIncentive> GetPerformanceIncentiveByName(string Name);

    }
    public class PerformanceIncentiveService : IPerformanceIncentiveService
    {
        private readonly IPerformanceIncentiveRepository _PerformanceIncentiveRepository;

        public PerformanceIncentiveService(IPerformanceIncentiveRepository PerformanceIncentiveRepository)
        {
            _PerformanceIncentiveRepository = PerformanceIncentiveRepository;    
        }
        
       
        public PerformanceIncentive GetPerformanceIncentive(int id)
        {
            return _PerformanceIncentiveRepository.GetPerformanceIncentive(id);
        }

        public List<PerformanceIncentive> GetPerformanceIncentiveByName(string Name)
        {
            return _PerformanceIncentiveRepository.GetPerformanceIncentiveByName(Name);
        }

        public PerformanceIncentive CreatePerformanceIncentive(PerformanceIncentiveDto PerformanceIncentiveDto)
        {
            return _PerformanceIncentiveRepository.CreatePerformanceIncentive(PerformanceIncentiveDto);
        }
        public List<PerformanceIncentiveDto> GetALl()
        {
            return _PerformanceIncentiveRepository.GetAll().Select(_PerformanceIncentiveRepository.ToPerformanceIncentiveDto).ToList();
        }

    }
}