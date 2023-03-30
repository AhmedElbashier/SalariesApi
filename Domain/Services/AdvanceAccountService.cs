using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IAdvanceAccountService
    {
        AdvanceAccount GetAdvanceAccount(int id);
        List<AdvanceAccountDto> GetALl();
        AdvanceAccount CreateAdvanceAccount(AdvanceAccountDto AdvanceAccountDto);
        List<AdvanceAccount> GetAdvanceAccountByEmpId(string EmpId);
        List<AdvanceAccount> GetAdvanceAccountByName(string Name);

    }
    public class AdvanceAccountService : IAdvanceAccountService
    {
        private readonly IAdvanceAccountRepository _AdvanceAccountRepository;

        public AdvanceAccountService(IAdvanceAccountRepository AdvanceAccountRepository)
        {
            _AdvanceAccountRepository = AdvanceAccountRepository;    
        }
        
       
        public AdvanceAccount GetAdvanceAccount(int id)
        {
            return _AdvanceAccountRepository.GetAdvanceAccount(id);
        }

        public List<AdvanceAccount> GetAdvanceAccountByName(string Name)
        {
            return _AdvanceAccountRepository.GetAdvanceAccountByName(Name);
        }
        public List<AdvanceAccount> GetAdvanceAccountByEmpId(string EmpId)
        {
            return _AdvanceAccountRepository.GetAdvanceAccountByEmpId(EmpId);
        }
        public AdvanceAccount CreateAdvanceAccount(AdvanceAccountDto AdvanceAccountDto)
        {
            return _AdvanceAccountRepository.CreateAdvanceAccount(AdvanceAccountDto);
        }
        public List<AdvanceAccountDto> GetALl()
        {
            return _AdvanceAccountRepository.GetAll().Select(_AdvanceAccountRepository.ToAdvanceAccountDto).ToList();
        }

    }
}