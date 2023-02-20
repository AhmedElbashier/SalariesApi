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
    public class LastSocialInsuranceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILastSocialInsuranceService _LastSocialInsuranceService;

        public LastSocialInsuranceController(AppDbContext context, ILastSocialInsuranceService LastSocialInsuranceService)
        {
            _context = context;
            _LastSocialInsuranceService = LastSocialInsuranceService;
        }

        [HttpGet]
        public IActionResult GetLastSocialInsurances()
        {
            var LastSocialInsurances = _LastSocialInsuranceService.GetALl();
            return Ok(LastSocialInsurances);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<LastSocialInsurance> GetLastSocialInsurance(int Id)
        {
            var LastSocialInsurance = _LastSocialInsuranceService.GetLastSocialInsurance(Id);

            if (LastSocialInsurance == null)
            {
                return NotFound();
            }

            return Ok(LastSocialInsurance);
        }
        
        [HttpGet("ByName/{LastSocialInsurancename}")]
        public IActionResult GetLastSocialInsuranceByName(string LastSocialInsurancename)
        {
            var LastSocialInsurance =  _LastSocialInsuranceService.GetLastSocialInsuranceByName(LastSocialInsurancename);
            return Ok(LastSocialInsurance);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutLastSocialInsurance(int Id, LastSocialInsurance LastSocialInsurance)
        {
            if (Id != LastSocialInsurance.Id)
            {
                return BadRequest();
            }

            _context.Entry(LastSocialInsurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LastSocialInsuranceExists(Id))
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
        public IActionResult CreateLastSocialInsurance(LastSocialInsuranceDto LastSocialInsuranceDto)
        {
            var LastSocialInsurance = _LastSocialInsuranceService.CreateLastSocialInsurance(LastSocialInsuranceDto);
            return Ok(LastSocialInsurance);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<LastSocialInsurance>> DeleteLastSocialInsurance(int Id)
        {
            var LastSocialInsurance = await _context.LastSocialInsurances.FindAsync(Id);
            if (LastSocialInsurance == null)
            {
                return NotFound();
            }

            _context.LastSocialInsurances.Remove(LastSocialInsurance);
            await _context.SaveChangesAsync();

            return LastSocialInsurance;
        }

               private bool LastSocialInsuranceExists(int Id)
        {
            return _context.LastSocialInsurances.Any(e => e.Id == Id);
        }
    }
}