using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IAbsenceService
    {
        Absence GetAbsence(int id);
        List<AbsenceDto> GetALl();
        Absence CreateAbsence(AbsenceDto AbsenceDto);
        List<Absence> GetAbsenceByName(string Name);
        List<Absence> GetAbsenceByEmpId(string EmpId);
        List<Absence> GetAbsenceByNameAndExp(string EmployeeName, string Month);

    }
    public class AbsenceService : IAbsenceService
    {
        private readonly IAbsenceRepository _AbsenceRepository;

        public AbsenceService(IAbsenceRepository AbsenceRepository)
        {
            _AbsenceRepository = AbsenceRepository;    
        }
        
       
        public Absence GetAbsence(int id)
        {
            return _AbsenceRepository.GetAbsence(id);
        }

        public List<Absence> GetAbsenceByName(string Name)
        {
            return _AbsenceRepository.GetAbsenceByName(Name);
        }
        public List<Absence> GetAbsenceByEmpId(string EmpId)
        {
            return _AbsenceRepository.GetAbsenceByEmpId(EmpId);
        }
        public List<Absence> GetAbsenceByNameAndExp(string EmployeeName, string Month)
        {
            return _AbsenceRepository.GetAbsenceByNameAndExp(EmployeeName,Month);
        }

        public Absence CreateAbsence(AbsenceDto AbsenceDto)
        {
            return _AbsenceRepository.CreateAbsence(AbsenceDto);
        }
        public List<AbsenceDto> GetALl()
        {
            return _AbsenceRepository.GetAll().Select(_AbsenceRepository.ToAbsenceDto).ToList();
        }

    }
}