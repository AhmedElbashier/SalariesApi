using Microsoft.AspNetCore.Mvc;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Services;
using SalariesApi.Domain.Models.Settings;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Linq;

namespace SalariesApi.Domain.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RoleController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IRoleService _RoleService;

        public RoleController(AppDbContext context, IRoleService RoleService)
        {
            _context = context;
            _RoleService = RoleService;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var Roles = _RoleService.GetALl();
            return Ok(Roles);
        }

        [HttpGet("{Id}")]
        public ActionResult<Role> GetRole(int Id)
        {
            var Role = _RoleService.GetRole(Id);

            if (Role == null)
            {
                return NotFound();
            }

            return Ok(Role);
        }

        [HttpGet("ByName/{Rolename}")]
        public IActionResult GetRoleByName(bool Rolename)
        {
            var Role = _RoleService.GetRoleByName(Rolename);
            return Ok(Role);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutRole(int Id, Role Role)
        {
            if (Id != Role.Id)
            {
                return BadRequest();
            }

            _context.Entry(Role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpPost]
        public IActionResult CreateRole(RoleDto RoleDto)
        {
            var Role = _RoleService.CreateRole(RoleDto);
            return Ok(Role);
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult<Role>> DeleteRole(int Id)
        {
            var Role = await _context.Roles.FindAsync(Id);
            if (Role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(Role);
            await _context.SaveChangesAsync();

            return Role;
        }

        private bool RoleExists(int Id)
        {
            return _context.Roles.Any(e => e.Id == Id);
        }
    }
}