using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IPartialAdvanceService
    {
        PartialAdvance GetPartialAdvance(int id);
        List<PartialAdvanceDto> GetALl();
        PartialAdvance CreatePartialAdvance(PartialAdvanceDto PartialAdvanceDto);
        List<PartialAdvance> GetPartialAdvanceByEmpId(string EmpId);
        List<PartialAdvance> GetPartialAdvanceByName(string Name);

    }
    public class PartialAdvanceService : IPartialAdvanceService
    {
        private readonly IPartialAdvanceRepository _PartialAdvanceRepository;

        public PartialAdvanceService(IPartialAdvanceRepository PartialAdvanceRepository)
        {
            _PartialAdvanceRepository = PartialAdvanceRepository;    
        }
        
       
        public PartialAdvance GetPartialAdvance(int id)
        {
            return _PartialAdvanceRepository.GetPartialAdvance(id);
        }

        public List<PartialAdvance> GetPartialAdvanceByName(string Name)
        {
            return _PartialAdvanceRepository.GetPartialAdvanceByName(Name);
        }
        public List<PartialAdvance> GetPartialAdvanceByEmpId(string EmpId)
        {
            return _PartialAdvanceRepository.GetPartialAdvanceByEmpId(EmpId);
        }
        public PartialAdvance CreatePartialAdvance(PartialAdvanceDto PartialAdvanceDto)
        {
            return _PartialAdvanceRepository.CreatePartialAdvance(PartialAdvanceDto);
        }
        public List<PartialAdvanceDto> GetALl()
        {
            return _PartialAdvanceRepository.GetAll().Select(_PartialAdvanceRepository.ToPartialAdvanceDto).ToList();
        }

    }
}