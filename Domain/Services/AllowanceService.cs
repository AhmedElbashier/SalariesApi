using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IAllowanceService
    {
        Allowance GetAllowance(int id);
        List<AllowanceDto> GetALl();
        Allowance CreateAllowance(AllowanceDto AllowanceDto);
        List<Allowance> GetAllowanceByName(string Name);

    }
    public class AllowanceService : IAllowanceService
    {
        private readonly IAllowanceRepository _AllowanceRepository;

        public AllowanceService(IAllowanceRepository AllowanceRepository)
        {
            _AllowanceRepository = AllowanceRepository;    
        }
        
       
        public Allowance GetAllowance(int id)
        {
            return _AllowanceRepository.GetAllowance(id);
        }

        public List<Allowance> GetAllowanceByName(string Name)
        {
            return _AllowanceRepository.GetAllowanceByName(Name);
        }

        public Allowance CreateAllowance(AllowanceDto AllowanceDto)
        {
            return _AllowanceRepository.CreateAllowance(AllowanceDto);
        }
        public List<AllowanceDto> GetALl()
        {
            return _AllowanceRepository.GetAll().Select(_AllowanceRepository.ToAllowanceDto).ToList();
        }

    }
}