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
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IEmployeeService _EmployeeService;

        public EmployeeController(AppDbContext context, IEmployeeService EmployeeService)
        {
            _context = context;
            _EmployeeService = EmployeeService;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var Employees = _EmployeeService.GetALl();
            return Ok(Employees);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<Employee> GetEmployee(int Id)
        {
            var Employee = _EmployeeService.GetEmployee(Id);

            if (Employee == null)
            {
                return NotFound();
            }

            return Ok(Employee);
        }
        
        [HttpGet("ByName/{Employeename}")]
        public IActionResult GetEmployeeByName(string Employeename)
        {
            var Employee =  _EmployeeService.GetEmployeeByName(Employeename);
            return Ok(Employee);
        }
        [HttpGet("ByTt/{EmployeeTt}")]
        public IActionResult GetEmployeeByTt(string EmployeeTt)
        {
            var Employee =  _EmployeeService.GetEmployeeByTt(EmployeeTt);
            return Ok(Employee);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutEmployee(int Id, Employee Employee)
        {
            if (Id != Employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(Employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Id))
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
        public IActionResult CreateEmployee(EmployeeDto EmployeeDto)
        {
            var Employee = _EmployeeService.CreateEmployee(EmployeeDto);
            return Ok(Employee);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int Id)
        {
            var Employee = await _context.Employees.FindAsync(Id);
            if (Employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(Employee);
            await _context.SaveChangesAsync();

            return Employee;
        }

               private bool EmployeeExists(int Id)
        {
            return _context.Employees.Any(e => e.Id == Id);
        }
    }
}