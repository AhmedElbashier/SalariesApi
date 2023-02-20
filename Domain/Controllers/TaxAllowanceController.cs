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
    public class TaxAllowanceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITaxAllowanceService _TaxAllowanceService;

        public TaxAllowanceController(AppDbContext context, ITaxAllowanceService TaxAllowanceService)
        {
            _context = context;
            _TaxAllowanceService = TaxAllowanceService;
        }

        [HttpGet]
        public IActionResult GetTaxAllowances()
        {
            var TaxAllowances = _TaxAllowanceService.GetALl();
            return Ok(TaxAllowances);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<TaxAllowance> GetTaxAllowance(int Id)
        {
            var TaxAllowance = _TaxAllowanceService.GetTaxAllowance(Id);

            if (TaxAllowance == null)
            {
                return NotFound();
            }

            return Ok(TaxAllowance);
        }
        
        [HttpGet("ByName/{TaxAllowancename}")]
        public IActionResult GetTaxAllowanceByName(string TaxAllowancename)
        {
            var TaxAllowance =  _TaxAllowanceService.GetTaxAllowanceByName(TaxAllowancename);
            return Ok(TaxAllowance);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutTaxAllowance(int Id, TaxAllowance TaxAllowance)
        {
            if (Id != TaxAllowance.Id)
            {
                return BadRequest();
            }

            _context.Entry(TaxAllowance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxAllowanceExists(Id))
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
        public IActionResult CreateTaxAllowance(TaxAllowanceDto TaxAllowanceDto)
        {
            var TaxAllowance = _TaxAllowanceService.CreateTaxAllowance(TaxAllowanceDto);
            return Ok(TaxAllowance);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<TaxAllowance>> DeleteTaxAllowance(int Id)
        {
            var TaxAllowance = await _context.TaxAllowances.FindAsync(Id);
            if (TaxAllowance == null)
            {
                return NotFound();
            }

            _context.TaxAllowances.Remove(TaxAllowance);
            await _context.SaveChangesAsync();

            return TaxAllowance;
        }

               private bool TaxAllowanceExists(int Id)
        {
            return _context.TaxAllowances.Any(e => e.Id == Id);
        }
    }
}