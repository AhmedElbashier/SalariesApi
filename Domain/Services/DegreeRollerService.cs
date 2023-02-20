using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IDegreeRollerService
    {
        DegreeRoller GetDegreeRoller(int id);
        List<DegreeRollerDto> GetALl();
        DegreeRoller CreateDegreeRoller(DegreeRollerDto DegreeRollerDto);
        List<DegreeRoller> GetDegreeRollerByName(string Name);
        List<DegreeRoller> GetDegreeRollerByNameAndExp(string DegreeRollerName, string DegreeRollerExp,string DegreeRollerEmpType);

    }
    public class DegreeRollerService : IDegreeRollerService
    {
        private readonly IDegreeRollerRepository _DegreeRollerRepository;

        public DegreeRollerService(IDegreeRollerRepository DegreeRollerRepository)
        {
            _DegreeRollerRepository = DegreeRollerRepository;    
        }
        
       
        public DegreeRoller GetDegreeRoller(int id)
        {
            return _DegreeRollerRepository.GetDegreeRoller(id);
        }

        public List<DegreeRoller> GetDegreeRollerByName(string Name)
        {
            return _DegreeRollerRepository.GetDegreeRollerByName(Name);
        }
        public List<DegreeRoller> GetDegreeRollerByNameAndExp(string DegreeRollerName, string DegreeRollerExp,string DegreeRollerEmpType)
        {
            return _DegreeRollerRepository.GetDegreeRollerByNameAndExp(DegreeRollerName,DegreeRollerExp,DegreeRollerEmpType);
        }

        public DegreeRoller CreateDegreeRoller(DegreeRollerDto DegreeRollerDto)
        {
            return _DegreeRollerRepository.CreateDegreeRoller(DegreeRollerDto);
        }
        public List<DegreeRollerDto> GetALl()
        {
            return _DegreeRollerRepository.GetAll().Select(_DegreeRollerRepository.ToDegreeRollerDto).ToList();
        }

    }
}