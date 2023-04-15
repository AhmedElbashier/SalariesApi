using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IPartialAdvanceAccountService
    {
        PartialAdvanceAccount GetPartialAdvanceAccount(int id);
        List<PartialAdvanceAccountDto> GetALl();
        PartialAdvanceAccount CreatePartialAdvanceAccount(PartialAdvanceAccountDto PartialAdvanceAccountDto);
        List<PartialAdvanceAccount> GetPartialAdvanceAccountByEmpId(string EmpId);
        List<PartialAdvanceAccount> GetPartialAdvanceAccountByName(string Name);

    }
    public class PartialAdvanceAccountService : IPartialAdvanceAccountService
    {
        private readonly IPartialAdvanceAccountRepository _PartialAdvanceAccountRepository;

        public PartialAdvanceAccountService(IPartialAdvanceAccountRepository PartialAdvanceAccountRepository)
        {
            _PartialAdvanceAccountRepository = PartialAdvanceAccountRepository;    
        }
        
       
        public PartialAdvanceAccount GetPartialAdvanceAccount(int id)
        {
            return _PartialAdvanceAccountRepository.GetPartialAdvanceAccount(id);
        }

        public List<PartialAdvanceAccount> GetPartialAdvanceAccountByName(string Name)
        {
            return _PartialAdvanceAccountRepository.GetPartialAdvanceAccountByName(Name);
        }
        public List<PartialAdvanceAccount> GetPartialAdvanceAccountByEmpId(string EmpId)
        {
            return _PartialAdvanceAccountRepository.GetPartialAdvanceAccountByEmpId(EmpId);
        }
        public PartialAdvanceAccount CreatePartialAdvanceAccount(PartialAdvanceAccountDto PartialAdvanceAccountDto)
        {
            return _PartialAdvanceAccountRepository.CreatePartialAdvanceAccount(PartialAdvanceAccountDto);
        }
        public List<PartialAdvanceAccountDto> GetALl()
        {
            return _PartialAdvanceAccountRepository.GetAll().Select(_PartialAdvanceAccountRepository.ToPartialAdvanceAccountDto).ToList();
        }

    }
}