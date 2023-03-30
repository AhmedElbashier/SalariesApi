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
    public class AdvanceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAdvanceService _AdvanceService;

        public AdvanceController(AppDbContext context, IAdvanceService AdvanceService)
        {
            _context = context;
            _AdvanceService = AdvanceService;
        }

        [HttpGet]
        public IActionResult GetAdvances()
        {
            var Advances = _AdvanceService.GetALl();
            return Ok(Advances);
        }

        [HttpGet("{Id}")]
        public ActionResult<Advance> GetAdvance(int Id)
        {
            var Advance = _AdvanceService.GetAdvance(Id);

            if (Advance == null)
            {
                return NotFound();
            }

            return Ok(Advance);
        }

        [HttpGet("ByName/{Advancename}")]
        public IActionResult GetAdvanceByName(string Advancename)
        {
            var Advance = _AdvanceService.GetAdvanceByName(Advancename);
            return Ok(Advance);
        }
        [HttpGet("ByEmpId/{EmpId}")]
        public IActionResult GetAdvanceByEmpId(string EmpId)
        {
            var Advance =  _AdvanceService.GetAdvanceByEmpId(EmpId);
            return Ok(Advance);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutAdvance(int Id, Advance Advance)
        {
            if (Id != Advance.Id)
            {
                return BadRequest();
            }

            _context.Entry(Advance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvanceExists(Id))
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
        public IActionResult CreateAdvance(AdvanceDto AdvanceDto)
        {
            var Advance = _AdvanceService.CreateAdvance(AdvanceDto);
            return Ok(Advance);
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult<Advance>> DeleteAdvance(int Id)
        {
            var Advance = await _context.Advances.FindAsync(Id);
            if (Advance == null)
            {
                return NotFound();
            }

            _context.Advances.Remove(Advance);
            await _context.SaveChangesAsync();

            return Advance;
        }

        private bool AdvanceExists(int Id)
        {
            return _context.Advances.Any(e => e.Id == Id);
        }
    }
}