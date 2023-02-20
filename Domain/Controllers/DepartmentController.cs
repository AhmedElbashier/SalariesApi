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
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IDepartmentService _DepartmentService;

        public DepartmentController(AppDbContext context, IDepartmentService DepartmentService)
        {
            _context = context;
            _DepartmentService = DepartmentService;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            var Departments = _DepartmentService.GetALl();
            return Ok(Departments);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<Department> GetDepartment(int Id)
        {
            var Department = _DepartmentService.GetDepartment(Id);

            if (Department == null)
            {
                return NotFound();
            }

            return Ok(Department);
        }
        
        [HttpGet("ByType/{Type}")]
        public IActionResult GetDepartmentByType(string Type)
        {
            var Department =  _DepartmentService.GetDepartmentByType(Type);
            return Ok(Department);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutDepartment(int Id, Department Department)
        {
            if (Id != Department.Id)
            {
                return BadRequest();
            }

            _context.Entry(Department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(Id))
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
        public IActionResult CreateDepartment(DepartmentDto DepartmentDto)
        {
            var Department = _DepartmentService.CreateDepartment(DepartmentDto);
            return Ok(Department);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int Id)
        {
            var Department = await _context.Departments.FindAsync(Id);
            if (Department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(Department);
            await _context.SaveChangesAsync();

            return Department;
        }

               private bool DepartmentExists(int Id)
        {
            return _context.Departments.Any(e => e.Id == Id);
        }
    }
}