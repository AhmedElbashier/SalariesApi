using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IPackagePayRollRepository
    {
        List<PackagePayRoll> GetAll();
        PackagePayRoll Find(int id);
        PackagePayRoll CreatePackagePayRoll(PackagePayRollDto PackagePayRollDto);
        PackagePayRollDto ToPackagePayRollDto(PackagePayRoll PackagePayRoll);
        PackagePayRoll GetPackagePayRoll(int id);
        List<PackagePayRoll> GetPackagePayRollById(int PackagePayRollId);
        List<PackagePayRoll> GetPackagePayRollByIdAndMonthYear(string PackageId, string PayRollMonth, string PayRollYear);



    }

    public class PackagePayRollRepository : IPackagePayRollRepository
    {
        private readonly AppDbContext _context;
        public PackagePayRollRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<PackagePayRoll> GetAll()
        {
            return _context.PackagePayRolls.ToList();
        }

        public PackagePayRoll Find(int id)
        {
            return _context.PackagePayRolls.Find(id);
        }

        public PackagePayRoll CreatePackagePayRoll(PackagePayRollDto PackagePayRollDto)
        {   
            var PackagePayRoll = ToPackagePayRoll(PackagePayRollDto);
            _context.PackagePayRolls.Add(PackagePayRoll);
            this._context.SaveChanges();
            return PackagePayRoll;
        }

        private PackagePayRoll ToPackagePayRoll(PackagePayRollDto PackagePayRollDto)
        {
            return new PackagePayRoll
            {   

                Id= PackagePayRollDto.Id,
                PackageId= PackagePayRollDto.PackageId,
                Name= PackagePayRollDto.Name,
                Program= PackagePayRollDto.Program,
                Sylbus= PackagePayRollDto.Sylbus,
                Semester= PackagePayRollDto.Semester,
                Period= PackagePayRollDto.Period,
                FirstMonth= PackagePayRollDto.FirstMonth,
                SecondMonth= PackagePayRollDto.SecondMonth,
                ThirdMonth= PackagePayRollDto.ThirdMonth,
                Amount= PackagePayRollDto.Amount,
                PayRollMonth= PackagePayRollDto.PayRollMonth,
                PayRollYear= PackagePayRollDto.PayRollYear,
                User= PackagePayRollDto.User,
                Left= PackagePayRollDto.Left,
                
            };
        }

        public PackagePayRollDto ToPackagePayRollDto(PackagePayRoll PackagePayRoll)
        {
            return new PackagePayRollDto
            {
                Id= PackagePayRoll.Id,
                PackageId= PackagePayRoll.PackageId,
                Name= PackagePayRoll.Name,
                Program= PackagePayRoll.Program,
                Sylbus= PackagePayRoll.Sylbus,
                Semester= PackagePayRoll.Semester,
                Period= PackagePayRoll.Period,
                FirstMonth= PackagePayRoll.FirstMonth,
                SecondMonth= PackagePayRoll.SecondMonth,
                ThirdMonth= PackagePayRoll.ThirdMonth,
                Amount= PackagePayRoll.Amount,
                PayRollMonth= PackagePayRoll.PayRollMonth,
                PayRollYear= PackagePayRoll.PayRollYear,
                User= PackagePayRoll.User,
                Left= PackagePayRoll.Left,
            };
        }
        public List<PackagePayRoll> GetPackagePayRollByIdAndMonthYear(string PackageId, string PayRollMonth, string PayRollYear)
        {
        
            return _context.PackagePayRolls.Where(x =>
                x.PackageId==PackageId&&x.PayRollMonth==PayRollMonth&&x.PayRollYear==PayRollYear).ToList();

        }
         public List<PackagePayRoll> GetPackagePayRollById(int PackagePayRollId)
        {
        
            return _context.PackagePayRolls.Where(x =>
                x.Id==(PackagePayRollId)).ToList();

        }
          public PackagePayRoll GetPackagePayRoll(int id)
        {
            return _context.PackagePayRolls.Find(id);
        }
         public List<PackagePayRoll> GetALL()
        {
            return _context.PackagePayRolls.ToList();
        }
    }
}