using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IRoleService
    {
        Role GetRole(int id);
        List<RoleDto> GetALl();
        Role CreateRole(RoleDto RoleDto);
        List<Role> GetRoleByName(bool Name);

    }
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _RoleRepository;

        public RoleService(IRoleRepository RoleRepository)
        {
            _RoleRepository = RoleRepository;    
        }
        
       
        public Role GetRole(int id)
        {
            return _RoleRepository.GetRole(id);
        }

        public List<Role> GetRoleByName(bool Name)
        {
            return _RoleRepository.GetRoleByName(Name);
        }
        public Role CreateRole(RoleDto RoleDto)
        {
            return _RoleRepository.CreateRole(RoleDto);
        }
        public List<RoleDto> GetALl()
        {
            return _RoleRepository.GetAll().Select(_RoleRepository.ToRoleDto).ToList();
        }

    }
}