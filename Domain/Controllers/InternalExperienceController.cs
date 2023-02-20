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
    public class InternalExperienceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IInternalExperienceService _InternalExperienceService;

        public InternalExperienceController(AppDbContext context, IInternalExperienceService InternalExperienceService)
        {
            _context = context;
            _InternalExperienceService = InternalExperienceService;
        }

        [HttpGet]
        public IActionResult GetInternalExperiences()
        {
            var InternalExperiences = _InternalExperienceService.GetALl();
            return Ok(InternalExperiences);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<InternalExperience> GetInternalExperience(int Id)
        {
            var InternalExperience = _InternalExperienceService.GetInternalExperience(Id);

            if (InternalExperience == null)
            {
                return NotFound();
            }

            return Ok(InternalExperience);
        }
        
        [HttpGet("ByName/{InternalExperiencename}")]
        public IActionResult GetInternalExperienceByName(string InternalExperiencename)
        {
            var InternalExperience =  _InternalExperienceService.GetInternalExperienceByName(InternalExperiencename);
            return Ok(InternalExperience);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutInternalExperience(int Id, InternalExperience InternalExperience)
        {
            if (Id != InternalExperience.Id)
            {
                return BadRequest();
            }

            _context.Entry(InternalExperience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternalExperienceExists(Id))
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
        public IActionResult CreateInternalExperience(InternalExperienceDto InternalExperienceDto)
        {
            var InternalExperience = _InternalExperienceService.CreateInternalExperience(InternalExperienceDto);
            return Ok(InternalExperience);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<InternalExperience>> DeleteInternalExperience(int Id)
        {
            var InternalExperience = await _context.InternalExperiences.FindAsync(Id);
            if (InternalExperience == null)
            {
                return NotFound();
            }

            _context.InternalExperiences.Remove(InternalExperience);
            await _context.SaveChangesAsync();

            return InternalExperience;
        }

               private bool InternalExperienceExists(int Id)
        {
            return _context.InternalExperiences.Any(e => e.Id == Id);
        }
    }
}