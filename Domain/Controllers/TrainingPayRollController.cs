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
    public class TrainingPayRollController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITrainingPayRollService _TrainingPayRollService;

        public TrainingPayRollController(AppDbContext context, ITrainingPayRollService TrainingPayRollService)
        {
            _context = context;
            _TrainingPayRollService = TrainingPayRollService;
        }

        [HttpGet]
        public IActionResult GetTrainingPayRolls()
        {
            var TrainingPayRolls = _TrainingPayRollService.GetALl();
            return Ok(TrainingPayRolls);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<TrainingPayRoll> GetTrainingPayRoll(int Id)
        {
            var TrainingPayRoll = _TrainingPayRollService.GetTrainingPayRoll(Id);

            if (TrainingPayRoll == null)
            {
                return NotFound();
            }

            return Ok(TrainingPayRoll);
        }
        
        [HttpGet("ByIdAndMonth/{TrainingId}/{Month}")]
        public IActionResult GetTrainingPayRollByIdAndMonth(string TrainingId,string Month)
        {
            var PayRoll =  _TrainingPayRollService.GetTrainingPayRollByIdAndMonth(TrainingId,Month);
            return Ok(PayRoll);
        }
        [HttpGet("ById/{TrainingPayRollId}")]
        public IActionResult GetTrainingPayRollById(int TrainingPayRollId)
        {
            var TrainingPayRoll =  _TrainingPayRollService.GetTrainingPayRollById(TrainingPayRollId);
            return Ok(TrainingPayRoll);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutTrainingPayRoll(int Id, TrainingPayRoll TrainingPayRoll)
        {
            if (Id != TrainingPayRoll.Id)
            {
                return BadRequest();
            }

            _context.Entry(TrainingPayRoll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingPayRollExists(Id))
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
        public IActionResult CreateTrainingPayRoll(TrainingPayRollDto TrainingPayRollDto)
        {
            var TrainingPayRoll = _TrainingPayRollService.CreateTrainingPayRoll(TrainingPayRollDto);
            return Ok(TrainingPayRoll);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<TrainingPayRoll>> DeleteTrainingPayRoll(int Id)
        {
            var TrainingPayRoll = await _context.TrainingPayRolls.FindAsync(Id);
            if (TrainingPayRoll == null)
            {
                return NotFound();
            }

            _context.TrainingPayRolls.Remove(TrainingPayRoll);
            await _context.SaveChangesAsync();

            return TrainingPayRoll;
        }

               private bool TrainingPayRollExists(int Id)
        {
            return _context.TrainingPayRolls.Any(e => e.Id == Id);
        }
    }
}