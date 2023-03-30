using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IRoleRepository
    {
        List<Role> GetAll();
        Role Find(int id);
        Role CreateRole(RoleDto RoleDto);
        RoleDto ToRoleDto(Role Role);
        Role GetRole(int id);
        List<Role> GetRoleByName(bool Name);
    }

    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;
        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Role Find(int id)
        {
            return _context.Roles.Find(id);
        }

        public Role CreateRole(RoleDto RoleDto)
        {   
            var Role = ToRole(RoleDto);
            _context.Roles.Add(Role);
            this._context.SaveChanges();
            return Role;
        }

        private Role ToRole(RoleDto RoleDto)
        {
            return new Role
            {   

                AcademicEmp= RoleDto.AcademicEmp,
                AdminEmp = RoleDto.AdminEmp,
                AcademicPayRoll = RoleDto.AcademicPayRoll,
                AdminPayRoll = RoleDto.AdminPayRoll,
                PackagePayRoll = RoleDto.PackagePayRoll,
                TrainingPayRoll = RoleDto.TrainingPayRoll,
                Reports = RoleDto.Reports,
                Absence = RoleDto.Absence,
                Advance = RoleDto.Advance,
                Partial = RoleDto.Partial,
                Settings = RoleDto.Settings,
                
            };
        }

        public RoleDto ToRoleDto(Role Role)
        {
            return new RoleDto
            {
                Id= Role.Id,
                AcademicEmp= Role.AcademicEmp,
                AdminEmp = Role.AdminEmp,
                AcademicPayRoll = Role.AcademicPayRoll,
                AdminPayRoll = Role.AdminPayRoll,
                PackagePayRoll = Role.PackagePayRoll,
                TrainingPayRoll = Role.TrainingPayRoll,
                Reports = Role.Reports,
                Absence = Role.Absence,
                Advance = Role.Advance,
                Partial = Role.Partial,
                Settings = Role.Settings,
            };
        }
         public List<Role> GetRoleByName(bool Name)
        {
        
            return _context.Roles.Where(x =>
                x.Settings==(Name)).ToList();

        }
          public Role GetRole(int id)
        {
            return _context.Roles.Find(id);
        }
         public List<Role> GetALL()
        {
            return _context.Roles.ToList();
        }
    }
}