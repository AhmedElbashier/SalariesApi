using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IPartialAdvanceAccountRepository
    {
        List<PartialAdvanceAccount> GetAll();
        PartialAdvanceAccount Find(int id);
        PartialAdvanceAccount CreatePartialAdvanceAccount(PartialAdvanceAccountDto PartialAdvanceAccountDto);
        List<PartialAdvanceAccount> GetPartialAdvanceAccountByEmpId(string EmpId);
        PartialAdvanceAccountDto ToPartialAdvanceAccountDto(PartialAdvanceAccount PartialAdvanceAccount);
        PartialAdvanceAccount GetPartialAdvanceAccount(int id);
        List<PartialAdvanceAccount> GetPartialAdvanceAccountByName(string Name);
    }

    public class PartialAdvanceAccountRepository : IPartialAdvanceAccountRepository
    {
        private readonly AppDbContext _context;
        public PartialAdvanceAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<PartialAdvanceAccount> GetAll()
        {
            return _context.PartialAdvanceAccounts.ToList();
        }

        public PartialAdvanceAccount Find(int id)
        {
            return _context.PartialAdvanceAccounts.Find(id);
        }

        public PartialAdvanceAccount CreatePartialAdvanceAccount(PartialAdvanceAccountDto PartialAdvanceAccountDto)
        {   
            var PartialAdvanceAccount = ToPartialAdvanceAccount(PartialAdvanceAccountDto);
            _context.PartialAdvanceAccounts.Add(PartialAdvanceAccount);
            this._context.SaveChanges();
            return PartialAdvanceAccount;
        }

        private PartialAdvanceAccount ToPartialAdvanceAccount(PartialAdvanceAccountDto PartialAdvanceAccountDto)
        {
            return new PartialAdvanceAccount
            {   

                Id= PartialAdvanceAccountDto.Id,
                EmpId= PartialAdvanceAccountDto.EmpId,
                EmpName= PartialAdvanceAccountDto.EmpName,
                FirstMonth = PartialAdvanceAccountDto.FirstMonth,
                LastMonth = PartialAdvanceAccountDto.LastMonth,
                Debit = PartialAdvanceAccountDto.Debit,
                Credit = PartialAdvanceAccountDto.Credit,
                
            };
        }

        public PartialAdvanceAccountDto ToPartialAdvanceAccountDto(PartialAdvanceAccount PartialAdvanceAccount)
        {
            return new PartialAdvanceAccountDto
            {
                Id= PartialAdvanceAccount.Id,
                EmpId= PartialAdvanceAccount.EmpId,
                EmpName= PartialAdvanceAccount.EmpName,
                FirstMonth = PartialAdvanceAccount.FirstMonth,
                LastMonth = PartialAdvanceAccount.LastMonth,
                Debit = PartialAdvanceAccount.Debit,
                Credit = PartialAdvanceAccount.Credit,
            };
        }
         public List<PartialAdvanceAccount> GetPartialAdvanceAccountByName(string Name)
        {
        
            return _context.PartialAdvanceAccounts.Where(x =>
                x.EmpName==(Name)).ToList();

        }
        public List<PartialAdvanceAccount> GetPartialAdvanceAccountByEmpId(string EmpId)
        {
        
            return _context.PartialAdvanceAccounts.Where(x =>
                x.EmpId==(EmpId)).ToList();

        }
          public PartialAdvanceAccount GetPartialAdvanceAccount(int id)
        {
            return _context.PartialAdvanceAccounts.Find(id);
        }
         public List<PartialAdvanceAccount> GetALL()
        {
            return _context.PartialAdvanceAccounts.ToList();
        }
    }
}