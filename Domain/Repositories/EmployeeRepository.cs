using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee Find(int id);
        Employee CreateEmployee(EmployeeDto EmployeeDto);
        EmployeeDto ToEmployeeDto(Employee Employee);
        Employee GetEmployee(int id);
        List<Employee> GetEmployeeByName(string Name);
        List<Employee> GetEmployeeByTt(string EmployeeTt);


    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee Find(int id)
        {
            return _context.Employees.Find(id);
        }

        public Employee CreateEmployee(EmployeeDto EmployeeDto)
        {   
            var Employee = ToEmployee(EmployeeDto);
            _context.Employees.Add(Employee);
            this._context.SaveChanges();
            return Employee;
        }

        private Employee ToEmployee(EmployeeDto EmployeeDto)
        {
            return new Employee
            {   

                Name= EmployeeDto.Name,
                Exp = EmployeeDto.Exp,
                InternalExp = EmployeeDto.InternalExp,
                FIB = EmployeeDto.FIB,
                BOK = EmployeeDto.BOK,
                Dept = EmployeeDto.Dept,
                // PayrollType = EmployeeDto.PayrollType,
                RecuirtDate = EmployeeDto.RecuirtDate,
                NationalId = EmployeeDto.NationalId,
                Type = EmployeeDto.Type,
                Tt = EmployeeDto.Tt,
                Rate = EmployeeDto.Rate,
            };
        }

        public EmployeeDto ToEmployeeDto(Employee Employee)
        {
            return new EmployeeDto
            {
                Id= Employee.Id,
                Name= Employee.Name,
                Exp = Employee.Exp,
                InternalExp = Employee.InternalExp,
                FIB = Employee.FIB,
                BOK = Employee.BOK,
                Dept = Employee.Dept,
                // PayrollType = Employee.PayrollType,
                RecuirtDate = Employee.RecuirtDate,
                NationalId = Employee.NationalId,
                Type = Employee.Type,
                Tt = Employee.Tt,
                Rate = Employee.Rate,
            };
        }
         public List<Employee> GetEmployeeByName(string Name)
        {
        
            return _context.Employees.Where(x =>
                x.Name==(Name)).ToList();

        }
        public List<Employee> GetEmployeeByTt(string EmployeeTt)
        {
        
            return _context.Employees.Where(x =>
                x.Tt==(EmployeeTt)).ToList();
        }
          public Employee GetEmployee(int id)
        {
            return _context.Employees.Find(id);
        }
         public List<Employee> GetALL()
        {
            return _context.Employees.ToList();
        }
    }
}