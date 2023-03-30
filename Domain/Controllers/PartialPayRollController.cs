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
    public class PartialPayRollController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPartialPayRollService _PartialPayRollService;

        public PartialPayRollController(AppDbContext context, IPartialPayRollService PartialPayRollService)
        {
            _context = context;
            _PartialPayRollService = PartialPayRollService;
        }

        [HttpGet]
        public IActionResult GetPartialPayRolls()
        {
            var PartialPayRolls = _PartialPayRollService.GetALl();
            return Ok(PartialPayRolls);
        }

        [HttpGet("{Id}")]
        public ActionResult<PartialPayRoll> GetPartialPayRoll(int Id)
        {
            var PartialPayRoll = _PartialPayRollService.GetPartialPayRoll(Id);

            if (PartialPayRoll == null)
            {
                return NotFound();
            }

            return Ok(PartialPayRoll);
        }

        [HttpGet("ByName/{PartialPayRollname}")]
        public IActionResult GetPartialPayRollByName(string PartialPayRollname)
        {
            var PartialPayRoll = _PartialPayRollService.GetPartialPayRollByName(PartialPayRollname);
            return Ok(PartialPayRoll);
        }
        [HttpGet("ByIdAndMonth/{EmpId}/{Month}/{Year}")]
        public IActionResult GetPartialPayRollByIdAndMonthYear(string EmpId,string Month,string Year)
        {
            var PayRoll =  _PartialPayRollService.GetPartialPayRollByIdAndMonthYear(EmpId,Month,Year);
            return Ok(PayRoll);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutPartialPayRoll(int Id, PartialPayRoll PartialPayRoll)
        {
            if (Id != PartialPayRoll.Id)
            {
                return BadRequest();
            }

            _context.Entry(PartialPayRoll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartialPayRollExists(Id))
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
        public IActionResult CreatePartialPayRoll(PartialPayRollDto PartialPayRollDto)
        {
            var PartialPayRoll = _PartialPayRollService.CreatePartialPayRoll(PartialPayRollDto);
            return Ok(PartialPayRoll);
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult<PartialPayRoll>> DeletePartialPayRoll(int Id)
        {
            var PartialPayRoll = await _context.PartialPayRolls.FindAsync(Id);
            if (PartialPayRoll == null)
            {
                return NotFound();
            }

            _context.PartialPayRolls.Remove(PartialPayRoll);
            await _context.SaveChangesAsync();

            return PartialPayRoll;
        }

        private bool PartialPayRollExists(int Id)
        {
            return _context.PartialPayRolls.Any(e => e.Id == Id);
        }
    }
}