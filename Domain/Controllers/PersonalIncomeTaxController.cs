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
    public class PersonalIncomeTaxController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPersonalIncomeTaxService _PersonalIncomeTaxService;

        public PersonalIncomeTaxController(AppDbContext context, IPersonalIncomeTaxService PersonalIncomeTaxService)
        {
            _context = context;
            _PersonalIncomeTaxService = PersonalIncomeTaxService;
        }

        [HttpGet]
        public IActionResult GetPersonalIncomeTaxs()
        {
            var PersonalIncomeTaxs = _PersonalIncomeTaxService.GetALl();
            return Ok(PersonalIncomeTaxs);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<PersonalIncomeTax> GetPersonalIncomeTax(int Id)
        {
            var PersonalIncomeTax = _PersonalIncomeTaxService.GetPersonalIncomeTax(Id);

            if (PersonalIncomeTax == null)
            {
                return NotFound();
            }

            return Ok(PersonalIncomeTax);
        }
        
        [HttpGet("ByName/{PersonalIncomeTaxname}")]
        public IActionResult GetPersonalIncomeTaxByName(string PersonalIncomeTaxname)
        {
            var PersonalIncomeTax =  _PersonalIncomeTaxService.GetPersonalIncomeTaxByName(PersonalIncomeTaxname);
            return Ok(PersonalIncomeTax);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutPersonalIncomeTax(int Id, PersonalIncomeTax PersonalIncomeTax)
        {
            if (Id != PersonalIncomeTax.Id)
            {
                return BadRequest();
            }

            _context.Entry(PersonalIncomeTax).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalIncomeTaxExists(Id))
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
        public IActionResult CreatePersonalIncomeTax(PersonalIncomeTaxDto PersonalIncomeTaxDto)
        {
            var PersonalIncomeTax = _PersonalIncomeTaxService.CreatePersonalIncomeTax(PersonalIncomeTaxDto);
            return Ok(PersonalIncomeTax);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<PersonalIncomeTax>> DeletePersonalIncomeTax(int Id)
        {
            var PersonalIncomeTax = await _context.PersonalIncomeTaxes.FindAsync(Id);
            if (PersonalIncomeTax == null)
            {
                return NotFound();
            }

            _context.PersonalIncomeTaxes.Remove(PersonalIncomeTax);
            await _context.SaveChangesAsync();

            return PersonalIncomeTax;
        }

               private bool PersonalIncomeTaxExists(int Id)
        {
            return _context.PersonalIncomeTaxes.Any(e => e.Id == Id);
        }
    }
}