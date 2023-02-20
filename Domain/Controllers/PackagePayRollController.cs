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
    public class PackagePayRollController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPackagePayRollService _PackagePayRollService;

        public PackagePayRollController(AppDbContext context, IPackagePayRollService PackagePayRollService)
        {
            _context = context;
            _PackagePayRollService = PackagePayRollService;
        }

        [HttpGet]
        public IActionResult GetPackagePayRolls()
        {
            var PackagePayRolls = _PackagePayRollService.GetALl();
            return Ok(PackagePayRolls);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<PackagePayRoll> GetPackagePayRoll(int Id)
        {
            var PackagePayRoll = _PackagePayRollService.GetPackagePayRoll(Id);

            if (PackagePayRoll == null)
            {
                return NotFound();
            }

            return Ok(PackagePayRoll);
        }
        
        [HttpGet("ByIdAndMonth/{PackageId}/{PayRollMonth}")]
        public IActionResult GetPackagePayRollByIdAndMonth(string PackageId,string PayRollMonth)
        {
            var PayRoll =  _PackagePayRollService.GetPackagePayRollByIdAndMonth(PackageId,PayRollMonth);
            return Ok(PayRoll);
        }
        [HttpGet("ById/{PackagePayRollId}")]
        public IActionResult GetPackagePayRollById(int PackagePayRollId)
        {
            var PackagePayRoll =  _PackagePayRollService.GetPackagePayRollById(PackagePayRollId);
            return Ok(PackagePayRoll);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutPackagePayRoll(int Id, PackagePayRoll PackagePayRoll)
        {
            if (Id != PackagePayRoll.Id)
            {
                return BadRequest();
            }

            _context.Entry(PackagePayRoll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackagePayRollExists(Id))
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
        public IActionResult CreatePackagePayRoll(PackagePayRollDto PackagePayRollDto)
        {
            var PackagePayRoll = _PackagePayRollService.CreatePackagePayRoll(PackagePayRollDto);
            return Ok(PackagePayRoll);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<PackagePayRoll>> DeletePackagePayRoll(int Id)
        {
            var PackagePayRoll = await _context.PackagePayRolls.FindAsync(Id);
            if (PackagePayRoll == null)
            {
                return NotFound();
            }

            _context.PackagePayRolls.Remove(PackagePayRoll);
            await _context.SaveChangesAsync();

            return PackagePayRoll;
        }

               private bool PackagePayRollExists(int Id)
        {
            return _context.PackagePayRolls.Any(e => e.Id == Id);
        }
    }
}