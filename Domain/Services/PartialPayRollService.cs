using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IPartialPayRollService
    {
        PartialPayRoll GetPartialPayRoll(int id);
        List<PartialPayRollDto> GetALl();
        PartialPayRoll CreatePartialPayRoll(PartialPayRollDto PartialPayRollDto);
        List<PartialPayRoll> GetPartialPayRollByName(string Name);
        List<PartialPayRoll> GetPartialPayRollByIdAndMonthYear(string EmpId, string Month, string Year);
        

    }
    public class PartialPayRollService : IPartialPayRollService
    {
        private readonly IPartialPayRollRepository _PartialPayRollRepository;

        public PartialPayRollService(IPartialPayRollRepository PartialPayRollRepository)
        {
            _PartialPayRollRepository = PartialPayRollRepository;    
        }
        
       
        public PartialPayRoll GetPartialPayRoll(int id)
        {
            return _PartialPayRollRepository.GetPartialPayRoll(id);
        }

        public List<PartialPayRoll> GetPartialPayRollByIdAndMonthYear(string EmpId, string Month, string Year)
        {
            return _PartialPayRollRepository.GetPartialPayRollByIdAndMonthYear(EmpId,Month,Year);
        }
        public List<PartialPayRoll> GetPartialPayRollByName(string Name)
        {
            return _PartialPayRollRepository.GetPartialPayRollByName(Name);
        }
        public PartialPayRoll CreatePartialPayRoll(PartialPayRollDto PartialPayRollDto)
        {
            return _PartialPayRollRepository.CreatePartialPayRoll(PartialPayRollDto);
        }
        public List<PartialPayRollDto> GetALl()
        {
            return _PartialPayRollRepository.GetAll().Select(_PartialPayRollRepository.ToPartialPayRollDto).ToList();
        }

    }
}