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
    public class PartialController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPartialService _PartialService;

        public PartialController(AppDbContext context, IPartialService PartialService)
        {
            _context = context;
            _PartialService = PartialService;
        }

        [HttpGet]
        public IActionResult GetPartials()
        {
            var Partials = _PartialService.GetALl();
            return Ok(Partials);
        }

        [HttpGet("{Id}")]
        public ActionResult<Partial> GetPartial(int Id)
        {
            var Partial = _PartialService.GetPartial(Id);

            if (Partial == null)
            {
                return NotFound();
            }

            return Ok(Partial);
        }

        [HttpGet("ByName/{Partialname}")]
        public IActionResult GetPartialByName(string Partialname)
        {
            var Partial = _PartialService.GetPartialByName(Partialname);
            return Ok(Partial);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutPartial(int Id, Partial Partial)
        {
            if (Id != Partial.Id)
            {
                return BadRequest();
            }

            _context.Entry(Partial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartialExists(Id))
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
        public IActionResult CreatePartial(PartialDto PartialDto)
        {
            var Partial = _PartialService.CreatePartial(PartialDto);
            return Ok(Partial);
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult<Partial>> DeletePartial(int Id)
        {
            var Partial = await _context.Partials.FindAsync(Id);
            if (Partial == null)
            {
                return NotFound();
            }

            _context.Partials.Remove(Partial);
            await _context.SaveChangesAsync();

            return Partial;
        }

        private bool PartialExists(int Id)
        {
            return _context.Partials.Any(e => e.Id == Id);
        }
    }
}