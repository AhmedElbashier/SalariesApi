using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IStampBaseService
    {
        StampBase GetStampBase(int id);
        List<StampBaseDto> GetALl();
        StampBase CreateStampBase(StampBaseDto StampBaseDto);
        List<StampBase> GetStampBaseByName(string Name);

    }
    public class StampBaseService : IStampBaseService
    {
        private readonly IStampBaseRepository _StampBaseRepository;

        public StampBaseService(IStampBaseRepository StampBaseRepository)
        {
            _StampBaseRepository = StampBaseRepository;    
        }
        
       
        public StampBase GetStampBase(int id)
        {
            return _StampBaseRepository.GetStampBase(id);
        }

        public List<StampBase> GetStampBaseByName(string Name)
        {
            return _StampBaseRepository.GetStampBaseByName(Name);
        }

        public StampBase CreateStampBase(StampBaseDto StampBaseDto)
        {
            return _StampBaseRepository.CreateStampBase(StampBaseDto);
        }
        public List<StampBaseDto> GetALl()
        {
            return _StampBaseRepository.GetAll().Select(_StampBaseRepository.ToStampBaseDto).ToList();
        }

    }
}