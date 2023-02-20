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
    public class StampSignController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IStampSignService _StampSignService;

        public StampSignController(AppDbContext context, IStampSignService StampSignService)
        {
            _context = context;
            _StampSignService = StampSignService;
        }

        [HttpGet]
        public IActionResult GetStampSigns()
        {
            var StampSigns = _StampSignService.GetALl();
            return Ok(StampSigns);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<StampSign> GetStampSign(int Id)
        {
            var StampSign = _StampSignService.GetStampSign(Id);

            if (StampSign == null)
            {
                return NotFound();
            }

            return Ok(StampSign);
        }
        
        [HttpGet("ByName/{StampSignname}")]
        public IActionResult GetStampSignByName(string StampSignname)
        {
            var StampSign =  _StampSignService.GetStampSignByName(StampSignname);
            return Ok(StampSign);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutStampSign(int Id, StampSign StampSign)
        {
            if (Id != StampSign.Id)
            {
                return BadRequest();
            }

            _context.Entry(StampSign).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StampSignExists(Id))
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
        public IActionResult CreateStampSign(StampSignDto StampSignDto)
        {
            var StampSign = _StampSignService.CreateStampSign(StampSignDto);
            return Ok(StampSign);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<StampSign>> DeleteStampSign(int Id)
        {
            var StampSign = await _context.StampSigns.FindAsync(Id);
            if (StampSign == null)
            {
                return NotFound();
            }

            _context.StampSigns.Remove(StampSign);
            await _context.SaveChangesAsync();

            return StampSign;
        }

               private bool StampSignExists(int Id)
        {
            return _context.StampSigns.Any(e => e.Id == Id);
        }
    }
}