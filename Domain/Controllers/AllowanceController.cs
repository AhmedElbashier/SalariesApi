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
    public class AllowanceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAllowanceService _AllowanceService;

        public AllowanceController(AppDbContext context, IAllowanceService AllowanceService)
        {
            _context = context;
            _AllowanceService = AllowanceService;
        }

        [HttpGet]
        public IActionResult GetAllowances()
        {
            var Allowances = _AllowanceService.GetALl();
            return Ok(Allowances);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<Allowance> GetAllowance(int Id)
        {
            var Allowance = _AllowanceService.GetAllowance(Id);

            if (Allowance == null)
            {
                return NotFound();
            }

            return Ok(Allowance);
        }
        
        [HttpGet("ByName/{Name}")]
        public IActionResult GetAllowanceByName(string Name)
        {
            var Allowance =  _AllowanceService.GetAllowanceByName(Name);
            return Ok(Allowance);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutAllowance(int Id, Allowance Allowance)
        {
            if (Id != Allowance.Id)
            {
                return BadRequest();
            }

            _context.Entry(Allowance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllowanceExists(Id))
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
        public IActionResult CreateAllowance(AllowanceDto AllowanceDto)
        {
            var Allowance = _AllowanceService.CreateAllowance(AllowanceDto);
            return Ok(Allowance);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<Allowance>> DeleteAllowance(int Id)
        {
            var Allowance = await _context.Allowances.FindAsync(Id);
            if (Allowance == null)
            {
                return NotFound();
            }

            _context.Allowances.Remove(Allowance);
            await _context.SaveChangesAsync();

            return Allowance;
        }

               private bool AllowanceExists(int Id)
        {
            return _context.Allowances.Any(e => e.Id == Id);
        }
    }
}