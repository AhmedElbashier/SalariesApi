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
    public class PayRollController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPayRollService _PayRollService;

        public PayRollController(AppDbContext context, IPayRollService PayRollService)
        {
            _context = context;
            _PayRollService = PayRollService;
        }

        [HttpGet]
        public IActionResult GetPayRolls()
        {
            var PayRolls = _PayRollService.GetALl();
            return Ok(PayRolls);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<PayRoll> GetPayRoll(int Id)
        {
            var PayRoll = _PayRollService.GetPayRoll(Id);

            if (PayRoll == null)
            {
                return NotFound();
            }

            return Ok(PayRoll);
        }
        
        [HttpGet("ByIdAndMonth/{EmpId}/{Month}")]
        public IActionResult GetPayRollByIdAndMonth(string EmpId,string Month)
        {
            var PayRoll =  _PayRollService.GetPayRollByIdAndMonth(EmpId,Month);
            return Ok(PayRoll);
        }
            [HttpPut("{Id}")]
        public async Task<IActionResult> PutPayRoll(int Id, PayRoll PayRoll)
        {
            if (Id != PayRoll.Id)
            {
                return BadRequest();
            }

            _context.Entry(PayRoll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayRollExists(Id))
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
        public IActionResult CreatePayRoll(PayRollDto PayRollDto)
        {
            var PayRoll = _PayRollService.CreatePayRoll(PayRollDto);
            return Ok(PayRoll);
        }
     [HttpDelete("{Id}")]
        public async Task<ActionResult<PayRoll>> DeletePayRoll(int Id)
        {
            var PayRoll = await _context.PayRolls.FindAsync(Id);
            if (PayRoll == null)
            {
                return NotFound();
            }

            _context.PayRolls.Remove(PayRoll);
            await _context.SaveChangesAsync();

            return PayRoll;
        }

               private bool PayRollExists(int Id)
        {
            return _context.PayRolls.Any(e => e.Id == Id);
        }
    }
}