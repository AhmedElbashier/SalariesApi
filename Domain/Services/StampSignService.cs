using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IStampSignService
    {
        StampSign GetStampSign(int id);
        List<StampSignDto> GetALl();
        StampSign CreateStampSign(StampSignDto StampSignDto);
        List<StampSign> GetStampSignByName(string Name);

    }
    public class StampSignService : IStampSignService
    {
        private readonly IStampSignRepository _StampSignRepository;

        public StampSignService(IStampSignRepository StampSignRepository)
        {
            _StampSignRepository = StampSignRepository;    
        }
        
       
        public StampSign GetStampSign(int id)
        {
            return _StampSignRepository.GetStampSign(id);
        }

        public List<StampSign> GetStampSignByName(string Name)
        {
            return _StampSignRepository.GetStampSignByName(Name);
        }

        public StampSign CreateStampSign(StampSignDto StampSignDto)
        {
            return _StampSignRepository.CreateStampSign(StampSignDto);
        }
        public List<StampSignDto> GetALl()
        {
            return _StampSignRepository.GetAll().Select(_StampSignRepository.ToStampSignDto).ToList();
        }

    }
}