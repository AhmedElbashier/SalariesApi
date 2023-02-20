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
    public class PerformanceIncentiveController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPerformanceIncentiveService _PerformanceIncentiveService;

        public PerformanceIncentiveController(AppDbContext context, IPerformanceIncentiveService PerformanceIncentiveService)
        {
            _context = context;
            _PerformanceIncentiveService = PerformanceIncentiveService;
        }

        [HttpGet]
        public IActionResult GetPerformanceIncentives()
        {
            var PerformanceIncentives = _PerformanceIncentiveService.GetALl();
            return Ok(PerformanceIncentives);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<PerformanceIncentive> GetPerformanceIncentive(int Id)
        {
            var PerformanceIncentive = _PerformanceIncentiveService.GetPerformanceIncentive(Id);

            if (PerformanceIncentive == null)
            {
                return NotFound();
            }

            return Ok(PerformanceIncentive);
        }
        
        [HttpGet("ByName/{PerformanceIncentivename}")]
        public IActionResult GetPerformanceIncentiveByName(string PerformanceIncentivename)
        {
            var PerformanceIncentive =  _PerformanceIncentiveService.GetPerformanceIncentiveByName(PerformanceIncentivename);
            return Ok(PerformanceIncentive);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutPerformanceIncentive(int Id, PerformanceIncentive PerformanceIncentive)
        {
            if (Id != PerformanceIncentive.Id)
            {
                return BadRequest();
            }

            _context.Entry(PerformanceIncentive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformanceIncentiveExists(Id))
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
        public IActionResult CreatePerformanceIncentive(PerformanceIncentiveDto PerformanceIncentiveDto)
        {
            var PerformanceIncentive = _PerformanceIncentiveService.CreatePerformanceIncentive(PerformanceIncentiveDto);
            return Ok(PerformanceIncentive);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<PerformanceIncentive>> DeletePerformanceIncentive(int Id)
        {
            var PerformanceIncentive = await _context.PerformanceIncentives.FindAsync(Id);
            if (PerformanceIncentive == null)
            {
                return NotFound();
            }

            _context.PerformanceIncentives.Remove(PerformanceIncentive);
            await _context.SaveChangesAsync();

            return PerformanceIncentive;
        }

               private bool PerformanceIncentiveExists(int Id)
        {
            return _context.PerformanceIncentives.Any(e => e.Id == Id);
        }
    }
}