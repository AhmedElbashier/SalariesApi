using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IPackagePayRollService
    {
        PackagePayRoll GetPackagePayRoll(int id);
        List<PackagePayRollDto> GetALl();
        PackagePayRoll CreatePackagePayRoll(PackagePayRollDto PackagePayRollDto);
        List<PackagePayRoll> GetPackagePayRollById(int PackagePayRollId);
        List<PackagePayRoll> GetPackagePayRollByIdAndMonthYear(string PackageId, string PayRollMonth, string PayRollYear);

    }
    public class PackagePayRollService : IPackagePayRollService
    {
        private readonly IPackagePayRollRepository _PackagePayRollRepository;

        public PackagePayRollService(IPackagePayRollRepository PackagePayRollRepository)
        {
            _PackagePayRollRepository = PackagePayRollRepository;    
        }
        
       
        public PackagePayRoll GetPackagePayRoll(int id)
        {
            return _PackagePayRollRepository.GetPackagePayRoll(id);
        }

        public List<PackagePayRoll> GetPackagePayRollByIdAndMonthYear(string PackageId, string PayRollMonth, string PayRollYear)
        {
            return _PackagePayRollRepository.GetPackagePayRollByIdAndMonthYear(PackageId,PayRollMonth,PayRollYear);
        }
        public List<PackagePayRoll> GetPackagePayRollById(int PackagePayRollId)
        {
            return _PackagePayRollRepository.GetPackagePayRollById(PackagePayRollId);
        }

        public PackagePayRoll CreatePackagePayRoll(PackagePayRollDto PackagePayRollDto)
        {
            return _PackagePayRollRepository.CreatePackagePayRoll(PackagePayRollDto);
        }
        public List<PackagePayRollDto> GetALl()
        {
            return _PackagePayRollRepository.GetAll().Select(_PackagePayRollRepository.ToPackagePayRollDto).ToList();
        }

    }
}