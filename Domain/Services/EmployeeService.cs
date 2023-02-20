using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IEmployeeService
    {
        Employee GetEmployee(int id);
        List<EmployeeDto> GetALl();
        Employee CreateEmployee(EmployeeDto EmployeeDto);
        List<Employee> GetEmployeeByName(string Name);
        List<Employee> GetEmployeeByTt(string EmployeeTt);

    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeService(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;    
        }
        
       
        public Employee GetEmployee(int id)
        {
            return _EmployeeRepository.GetEmployee(id);
        }

        public List<Employee> GetEmployeeByName(string Name)
        {
            return _EmployeeRepository.GetEmployeeByName(Name);
        }
        public List<Employee> GetEmployeeByTt(string EmployeeTt)
        {
            return _EmployeeRepository.GetEmployeeByTt(EmployeeTt);
        }

        public Employee CreateEmployee(EmployeeDto EmployeeDto)
        {
            return _EmployeeRepository.CreateEmployee(EmployeeDto);
        }
        public List<EmployeeDto> GetALl()
        {
            return _EmployeeRepository.GetAll().Select(_EmployeeRepository.ToEmployeeDto).ToList();
        }

    }
}