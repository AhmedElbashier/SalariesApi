using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IPackageService
    {
        Package GetPackage(int id);
        List<PackageDto> GetALl();
        Package CreatePackage(PackageDto PackageDto);
        List<Package> GetPackageByName(string Name);

    }
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _PackageRepository;

        public PackageService(IPackageRepository PackageRepository)
        {
            _PackageRepository = PackageRepository;    
        }
        
       
        public Package GetPackage(int id)
        {
            return _PackageRepository.GetPackage(id);
        }

        public List<Package> GetPackageByName(string Name)
        {
            return _PackageRepository.GetPackageByName(Name);
        }

        public Package CreatePackage(PackageDto PackageDto)
        {
            return _PackageRepository.CreatePackage(PackageDto);
        }
        public List<PackageDto> GetALl()
        {
            return _PackageRepository.GetAll().Select(_PackageRepository.ToPackageDto).ToList();
        }

    }
}