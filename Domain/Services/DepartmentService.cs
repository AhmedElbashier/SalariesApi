using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IDepartmentService
    {
        Department GetDepartment(int id);
        List<DepartmentDto> GetALl();
        Department CreateDepartment(DepartmentDto DepartmentDto);
        List<Department> GetDepartmentByType(string Type);

    }
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _DepartmentRepository;

        public DepartmentService(IDepartmentRepository DepartmentRepository)
        {
            _DepartmentRepository = DepartmentRepository;    
        }
        
       
        public Department GetDepartment(int id)
        {
            return _DepartmentRepository.GetDepartment(id);
        }

        public List<Department> GetDepartmentByType(string Type)
        {
            return _DepartmentRepository.GetDepartmentByType(Type);
        }

        public Department CreateDepartment(DepartmentDto DepartmentDto)
        {
            return _DepartmentRepository.CreateDepartment(DepartmentDto);
        }
        public List<DepartmentDto> GetALl()
        {
            return _DepartmentRepository.GetAll().Select(_DepartmentRepository.ToDepartmentDto).ToList();
        }

    }
}