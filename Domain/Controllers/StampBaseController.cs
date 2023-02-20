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
    public class StampBaseController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IStampBaseService _StampBaseService;

        public StampBaseController(AppDbContext context, IStampBaseService StampBaseService)
        {
            _context = context;
            _StampBaseService = StampBaseService;
        }

        [HttpGet]
        public IActionResult GetStampBases()
        {
            var StampBases = _StampBaseService.GetALl();
            return Ok(StampBases);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<StampBase> GetStampBase(int Id)
        {
            var StampBase = _StampBaseService.GetStampBase(Id);

            if (StampBase == null)
            {
                return NotFound();
            }

            return Ok(StampBase);
        }
        
        [HttpGet("ByName/{StampBasename}")]
        public IActionResult GetStampBaseByName(string StampBasename)
        {
            var StampBase =  _StampBaseService.GetStampBaseByName(StampBasename);
            return Ok(StampBase);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutStampBase(int Id, StampBase StampBase)
        {
            if (Id != StampBase.Id)
            {
                return BadRequest();
            }

            _context.Entry(StampBase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StampBaseExists(Id))
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
        public IActionResult CreateStampBase(StampBaseDto StampBaseDto)
        {
            var StampBase = _StampBaseService.CreateStampBase(StampBaseDto);
            return Ok(StampBase);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<StampBase>> DeleteStampBase(int Id)
        {
            var StampBase = await _context.StampBases.FindAsync(Id);
            if (StampBase == null)
            {
                return NotFound();
            }

            _context.StampBases.Remove(StampBase);
            await _context.SaveChangesAsync();

            return StampBase;
        }

               private bool StampBaseExists(int Id)
        {
            return _context.StampBases.Any(e => e.Id == Id);
        }
    }
}