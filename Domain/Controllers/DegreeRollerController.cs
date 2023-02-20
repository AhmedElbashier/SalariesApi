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
    public class DegreeRollerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IDegreeRollerService _DegreeRollerService;

        public DegreeRollerController(AppDbContext context, IDegreeRollerService DegreeRollerService)
        {
            _context = context;
            _DegreeRollerService = DegreeRollerService;
        }

        [HttpGet]
        public IActionResult GetDegreeRollers()
        {
            var DegreeRollers = _DegreeRollerService.GetALl();
            return Ok(DegreeRollers);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<DegreeRoller> GetDegreeRoller(int Id)
        {
            var DegreeRoller = _DegreeRollerService.GetDegreeRoller(Id);

            if (DegreeRoller == null)
            {
                return NotFound();
            }

            return Ok(DegreeRoller);
        }
        
        [HttpGet("ByName/{DegreeRollername}")]
        public IActionResult GetDegreeRollerByName(string DegreeRollername)
        {
            var DegreeRoller =  _DegreeRollerService.GetDegreeRollerByName(DegreeRollername);
            return Ok(DegreeRoller);
        }

        [HttpGet("ByExp/{DegreeRollername}/{DegreeRollerExp}/{DegreeRollerEmpType}")]
        public IActionResult GetDegreeRollerByNameAndExp(string DegreeRollername,string DegreeRollerExp,string DegreeRollerEmpType)
        {
            var DegreeRoller =  _DegreeRollerService.GetDegreeRollerByNameAndExp(DegreeRollername,DegreeRollerExp,DegreeRollerEmpType);
            return Ok(DegreeRoller);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutDegreeRoller(int Id, DegreeRoller DegreeRoller)
        {
            if (Id != DegreeRoller.Id)
            {
                return BadRequest();
            }

            _context.Entry(DegreeRoller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DegreeRollerExists(Id))
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
        public IActionResult CreateDegreeRoller(DegreeRollerDto DegreeRollerDto)
        {
            var DegreeRoller = _DegreeRollerService.CreateDegreeRoller(DegreeRollerDto);
            return Ok(DegreeRoller);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<DegreeRoller>> DeleteDegreeRoller(int Id)
        {
            var DegreeRoller = await _context.DegreeRollers.FindAsync(Id);
            if (DegreeRoller == null)
            {
                return NotFound();
            }

            _context.DegreeRollers.Remove(DegreeRoller);
            await _context.SaveChangesAsync();

            return DegreeRoller;
        }

               private bool DegreeRollerExists(int Id)
        {
            return _context.DegreeRollers.Any(e => e.Id == Id);
        }
    }
}