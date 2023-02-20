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
    public class TrainingController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITrainingService _TrainingService;

        public TrainingController(AppDbContext context, ITrainingService TrainingService)
        {
            _context = context;
            _TrainingService = TrainingService;
        }

        [HttpGet]
        public IActionResult GetTrainings()
        {
            var Trainings = _TrainingService.GetALl();
            return Ok(Trainings);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<Training> GetTraining(int Id)
        {
            var Training = _TrainingService.GetTraining(Id);

            if (Training == null)
            {
                return NotFound();
            }

            return Ok(Training);
        }
        
        [HttpGet("ById/{TrainingId}")]
        public IActionResult GetTrainingById(int TrainingId)
        {
            var Training =  _TrainingService.GetTrainingById(TrainingId);
            return Ok(Training);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutTraining(int Id, Training Training)
        {
            if (Id != Training.Id)
            {
                return BadRequest();
            }

            _context.Entry(Training).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingExists(Id))
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
        public IActionResult CreateTraining(TrainingDto TrainingDto)
        {
            var Training = _TrainingService.CreateTraining(TrainingDto);
            return Ok(Training);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<Training>> DeleteTraining(int Id)
        {
            var Training = await _context.Trainings.FindAsync(Id);
            if (Training == null)
            {
                return NotFound();
            }

            _context.Trainings.Remove(Training);
            await _context.SaveChangesAsync();

            return Training;
        }

               private bool TrainingExists(int Id)
        {
            return _context.Trainings.Any(e => e.Id == Id);
        }
    }
}