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
    public class AbsenceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAbsenceService _AbsenceService;

        public AbsenceController(AppDbContext context, IAbsenceService AbsenceService)
        {
            _context = context;
            _AbsenceService = AbsenceService;
        }

        [HttpGet]
        public IActionResult GetAbsences()
        {
            var Absences = _AbsenceService.GetALl();
            return Ok(Absences);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<Absence> GetAbsence(int Id)
        {
            var Absence = _AbsenceService.GetAbsence(Id);

            if (Absence == null)
            {
                return NotFound();
            }

            return Ok(Absence);
        }
        
        [HttpGet("ByName/{Absencename}")]
        public IActionResult GetAbsenceByName(string Absencename)
        {
            var Absence =  _AbsenceService.GetAbsenceByName(Absencename);
            return Ok(Absence);
        }
        [HttpGet("ByEmpId/{EmpId}")]
        public IActionResult GetAbsenceByEmpId(string EmpId)
        {
            var Absence =  _AbsenceService.GetAbsenceByName(EmpId);
            return Ok(Absence);
        }

        [HttpGet("ByNameAndMonth/{Absencename}/{Month}/")]
        public IActionResult GetAbsenceByNameAndExp(string Absencename,string Month)
        {
            var Absence =  _AbsenceService.GetAbsenceByNameAndExp(Absencename,Month);
            return Ok(Absence);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutAbsence(int Id, Absence Absence)
        {
            if (Id != Absence.Id)
            {
                return BadRequest();
            }

            _context.Entry(Absence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbsenceExists(Id))
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
        public IActionResult CreateAbsence(AbsenceDto AbsenceDto)
        {
            var Absence = _AbsenceService.CreateAbsence(AbsenceDto);
            return Ok(Absence);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<Absence>> DeleteAbsence(int Id)
        {
            var Absence = await _context.Absences.FindAsync(Id);
            if (Absence == null)
            {
                return NotFound();
            }

            _context.Absences.Remove(Absence);
            await _context.SaveChangesAsync();

            return Absence;
        }

               private bool AbsenceExists(int Id)
        {
            return _context.Absences.Any(e => e.Id == Id);
        }
    }
}