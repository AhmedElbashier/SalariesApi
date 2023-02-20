using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department Find(int id);
        Department CreateDepartment(DepartmentDto DepartmentDto);
        DepartmentDto ToDepartmentDto(Department Department);
        Department GetDepartment(int id);
        List<Department> GetDepartmentByType(string Type);


    }

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department Find(int id)
        {
            return _context.Departments.Find(id);
        }

        public Department CreateDepartment(DepartmentDto DepartmentDto)
        {   
            var Department = ToDepartment(DepartmentDto);
            _context.Departments.Add(Department);
            this._context.SaveChanges();
            return Department;
        }

        private Department ToDepartment(DepartmentDto DepartmentDto)
        {
            return new Department
            {   

                Name= DepartmentDto.Name,
                Type= DepartmentDto.Type,
                
            };
        }

        public DepartmentDto ToDepartmentDto(Department Department)
        {
            return new DepartmentDto
            {
                Id= Department.Id,
                Name= Department.Name,
                Type= Department.Type,
            };
        }
         public List<Department> GetDepartmentByType(string Type)
        {
        
            return _context.Departments.Where(x =>
                x.Type==(Type)).ToList();

        }
          public Department GetDepartment(int id)
        {
            return _context.Departments.Find(id);
        }
         public List<Department> GetALL()
        {
            return _context.Departments.ToList();
        }
    }
}