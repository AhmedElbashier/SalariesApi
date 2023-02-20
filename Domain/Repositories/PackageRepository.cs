using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IPackageRepository
    {
        List<Package> GetAll();
        Package Find(int id);
        Package CreatePackage(PackageDto PackageDto);
        PackageDto ToPackageDto(Package Package);
        Package GetPackage(int id);
        List<Package> GetPackageByName(string Name);


    }

    public class PackageRepository : IPackageRepository
    {
        private readonly AppDbContext _context;
        public PackageRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Package> GetAll()
        {
            return _context.Packages.ToList();
        }

        public Package Find(int id)
        {
            return _context.Packages.Find(id);
        }

        public Package CreatePackage(PackageDto PackageDto)
        {   
            var Package = ToPackage(PackageDto);
            _context.Packages.Add(Package);
            this._context.SaveChanges();
            return Package;
        }

        private Package ToPackage(PackageDto PackageDto)
        {
            return new Package
            {   

                Name= PackageDto.Name,
                Program= PackageDto.Program,
                Semester= PackageDto.Semester,
                Sylbus= PackageDto.Sylbus,
                Period= PackageDto.Period,
                FirstMonth= PackageDto.FirstMonth,
                SecondMonth= PackageDto.SecondMonth,
                ThirdMonth= PackageDto.ThirdMonth,
                FirstMonthPayRoll= PackageDto.FirstMonthPayRoll,
                SecondMonthPayRoll= PackageDto.SecondMonthPayRoll,
                ThirdMonthPayRoll= PackageDto.ThirdMonthPayRoll,
                Amount= PackageDto.Amount,
            };
        }

        public PackageDto ToPackageDto(Package Package)
        {
            return new PackageDto
            {
                Id= Package.Id,
                Name= Package.Name,
                Program= Package.Program,
                Semester= Package.Semester,
                Sylbus= Package.Sylbus,
                Period= Package.Period,
                FirstMonth= Package.FirstMonth,
                SecondMonth= Package.SecondMonth,
                ThirdMonth= Package.ThirdMonth,
                FirstMonthPayRoll= Package.FirstMonthPayRoll,
                SecondMonthPayRoll= Package.SecondMonthPayRoll,
                ThirdMonthPayRoll= Package.ThirdMonthPayRoll,
                Amount= Package.Amount,
            };
        }
         public List<Package> GetPackageByName(string Name)
        {
        
            return _context.Packages.Where(x =>
                x.Name==(Name)).ToList();

        }
          public Package GetPackage(int id)
        {
            return _context.Packages.Find(id);
        }
         public List<Package> GetALL()
        {
            return _context.Packages.ToList();
        }
    }
}