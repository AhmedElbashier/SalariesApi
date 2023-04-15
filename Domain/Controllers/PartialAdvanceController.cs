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
    public class PartialAdvanceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPartialAdvanceService _PartialAdvanceService;

        public PartialAdvanceController(AppDbContext context, IPartialAdvanceService PartialAdvanceService)
        {
            _context = context;
            _PartialAdvanceService = PartialAdvanceService;
        }

        [HttpGet]
        public IActionResult GetPartialAdvances()
        {
            var PartialAdvances = _PartialAdvanceService.GetALl();
            return Ok(PartialAdvances);
        }

        [HttpGet("{Id}")]
        public ActionResult<PartialAdvance> GetPartialAdvance(int Id)
        {
            var PartialAdvance = _PartialAdvanceService.GetPartialAdvance(Id);

            if (PartialAdvance == null)
            {
                return NotFound();
            }

            return Ok(PartialAdvance);
        }

        [HttpGet("ByName/{PartialAdvancename}")]
        public IActionResult GetPartialAdvanceByName(string PartialAdvancename)
        {
            var PartialAdvance = _PartialAdvanceService.GetPartialAdvanceByName(PartialAdvancename);
            return Ok(PartialAdvance);
        }
        [HttpGet("ByEmpId/{EmpId}")]
        public IActionResult GetPartialAdvanceByEmpId(string EmpId)
        {
            var PartialAdvance =  _PartialAdvanceService.GetPartialAdvanceByEmpId(EmpId);
            return Ok(PartialAdvance);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutPartialAdvance(int Id, PartialAdvance PartialAdvance)
        {
            if (Id != PartialAdvance.Id)
            {
                return BadRequest();
            }

            _context.Entry(PartialAdvance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartialAdvanceExists(Id))
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
        public IActionResult CreatePartialAdvance(PartialAdvanceDto PartialAdvanceDto)
        {
            var PartialAdvance = _PartialAdvanceService.CreatePartialAdvance(PartialAdvanceDto);
            return Ok(PartialAdvance);
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult<PartialAdvance>> DeletePartialAdvance(int Id)
        {
            var PartialAdvance = await _context.PartialAdvances.FindAsync(Id);
            if (PartialAdvance == null)
            {
                return NotFound();
            }

            _context.PartialAdvances.Remove(PartialAdvance);
            await _context.SaveChangesAsync();

            return PartialAdvance;
        }

        private bool PartialAdvanceExists(int Id)
        {
            return _context.PartialAdvances.Any(e => e.Id == Id);
        }
    }
}