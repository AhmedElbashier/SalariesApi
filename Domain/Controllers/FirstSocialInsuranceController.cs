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
    public class FirstSocialInsuranceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IFirstSocialInsuranceService _FirstSocialInsuranceService;

        public FirstSocialInsuranceController(AppDbContext context, IFirstSocialInsuranceService FirstSocialInsuranceService)
        {
            _context = context;
            _FirstSocialInsuranceService = FirstSocialInsuranceService;
        }

        [HttpGet]
        public IActionResult GetFirstSocialInsurances()
        {
            var FirstSocialInsurances = _FirstSocialInsuranceService.GetALl();
            return Ok(FirstSocialInsurances);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<FirstSocialInsurance> GetFirstSocialInsurance(int Id)
        {
            var FirstSocialInsurance = _FirstSocialInsuranceService.GetFirstSocialInsurance(Id);

            if (FirstSocialInsurance == null)
            {
                return NotFound();
            }

            return Ok(FirstSocialInsurance);
        }
        
        [HttpGet("ByName/{FirstSocialInsurancename}")]
        public IActionResult GetFirstSocialInsuranceByName(string FirstSocialInsurancename)
        {
            var FirstSocialInsurance =  _FirstSocialInsuranceService.GetFirstSocialInsuranceByName(FirstSocialInsurancename);
            return Ok(FirstSocialInsurance);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutFirstSocialInsurance(int Id, FirstSocialInsurance FirstSocialInsurance)
        {
            if (Id != FirstSocialInsurance.Id)
            {
                return BadRequest();
            }

            _context.Entry(FirstSocialInsurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirstSocialInsuranceExists(Id))
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
        public IActionResult CreateFirstSocialInsurance(FirstSocialInsuranceDto FirstSocialInsuranceDto)
        {
            var FirstSocialInsurance = _FirstSocialInsuranceService.CreateFirstSocialInsurance(FirstSocialInsuranceDto);
            return Ok(FirstSocialInsurance);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<FirstSocialInsurance>> DeleteFirstSocialInsurance(int Id)
        {
            var FirstSocialInsurance = await _context.FirstSocialInsurances.FindAsync(Id);
            if (FirstSocialInsurance == null)
            {
                return NotFound();
            }

            _context.FirstSocialInsurances.Remove(FirstSocialInsurance);
            await _context.SaveChangesAsync();

            return FirstSocialInsurance;
        }

               private bool FirstSocialInsuranceExists(int Id)
        {
            return _context.FirstSocialInsurances.Any(e => e.Id == Id);
        }
    }
}