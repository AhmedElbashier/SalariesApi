using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IAdvanceAccountRepository
    {
        List<AdvanceAccount> GetAll();
        AdvanceAccount Find(int id);
        AdvanceAccount CreateAdvanceAccount(AdvanceAccountDto AdvanceAccountDto);
        List<AdvanceAccount> GetAdvanceAccountByEmpId(string EmpId);
        AdvanceAccountDto ToAdvanceAccountDto(AdvanceAccount AdvanceAccount);
        AdvanceAccount GetAdvanceAccount(int id);
        List<AdvanceAccount> GetAdvanceAccountByName(string Name);
    }

    public class AdvanceAccountRepository : IAdvanceAccountRepository
    {
        private readonly AppDbContext _context;
        public AdvanceAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<AdvanceAccount> GetAll()
        {
            return _context.AdvanceAccounts.ToList();
        }

        public AdvanceAccount Find(int id)
        {
            return _context.AdvanceAccounts.Find(id);
        }

        public AdvanceAccount CreateAdvanceAccount(AdvanceAccountDto AdvanceAccountDto)
        {   
            var AdvanceAccount = ToAdvanceAccount(AdvanceAccountDto);
            _context.AdvanceAccounts.Add(AdvanceAccount);
            this._context.SaveChanges();
            return AdvanceAccount;
        }

        private AdvanceAccount ToAdvanceAccount(AdvanceAccountDto AdvanceAccountDto)
        {
            return new AdvanceAccount
            {   

                Id= AdvanceAccountDto.Id,
                EmpId= AdvanceAccountDto.EmpId,
                EmpName= AdvanceAccountDto.EmpName,
                FirstMonth = AdvanceAccountDto.FirstMonth,
                LastMonth = AdvanceAccountDto.LastMonth,
                Debit = AdvanceAccountDto.Debit,
                Credit = AdvanceAccountDto.Credit,
                
            };
        }

        public AdvanceAccountDto ToAdvanceAccountDto(AdvanceAccount AdvanceAccount)
        {
            return new AdvanceAccountDto
            {
                Id= AdvanceAccount.Id,
                EmpId= AdvanceAccount.EmpId,
                EmpName= AdvanceAccount.EmpName,
                FirstMonth = AdvanceAccount.FirstMonth,
                LastMonth = AdvanceAccount.LastMonth,
                Debit = AdvanceAccount.Debit,
                Credit = AdvanceAccount.Credit,
            };
        }
         public List<AdvanceAccount> GetAdvanceAccountByName(string Name)
        {
        
            return _context.AdvanceAccounts.Where(x =>
                x.EmpName==(Name)).ToList();

        }
        public List<AdvanceAccount> GetAdvanceAccountByEmpId(string EmpId)
        {
        
            return _context.AdvanceAccounts.Where(x =>
                x.EmpId==(EmpId)).ToList();

        }
          public AdvanceAccount GetAdvanceAccount(int id)
        {
            return _context.AdvanceAccounts.Find(id);
        }
         public List<AdvanceAccount> GetALL()
        {
            return _context.AdvanceAccounts.ToList();
        }
    }
}