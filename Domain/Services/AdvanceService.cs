using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IAdvanceService
    {
        Advance GetAdvance(int id);
        List<AdvanceDto> GetALl();
        Advance CreateAdvance(AdvanceDto AdvanceDto);
        List<Advance> GetAdvanceByEmpId(string EmpId);
        List<Advance> GetAdvanceByName(string Name);

    }
    public class AdvanceService : IAdvanceService
    {
        private readonly IAdvanceRepository _AdvanceRepository;

        public AdvanceService(IAdvanceRepository AdvanceRepository)
        {
            _AdvanceRepository = AdvanceRepository;    
        }
        
       
        public Advance GetAdvance(int id)
        {
            return _AdvanceRepository.GetAdvance(id);
        }

        public List<Advance> GetAdvanceByName(string Name)
        {
            return _AdvanceRepository.GetAdvanceByName(Name);
        }
        public List<Advance> GetAdvanceByEmpId(string EmpId)
        {
            return _AdvanceRepository.GetAdvanceByEmpId(EmpId);
        }
        public Advance CreateAdvance(AdvanceDto AdvanceDto)
        {
            return _AdvanceRepository.CreateAdvance(AdvanceDto);
        }
        public List<AdvanceDto> GetALl()
        {
            return _AdvanceRepository.GetAll().Select(_AdvanceRepository.ToAdvanceDto).ToList();
        }

    }
}