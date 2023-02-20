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
    public class BookAndSearchController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IBookAndSearchService _BookAndSearchService;

        public BookAndSearchController(AppDbContext context, IBookAndSearchService BookAndSearchService)
        {
            _context = context;
            _BookAndSearchService = BookAndSearchService;
        }

        [HttpGet]
        public IActionResult GetBookAndSearchs()
        {
            var BookAndSearchs = _BookAndSearchService.GetALl();
            return Ok(BookAndSearchs);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<BookAndSearch> GetBookAndSearch(int Id)
        {
            var BookAndSearch = _BookAndSearchService.GetBookAndSearch(Id);

            if (BookAndSearch == null)
            {
                return NotFound();
            }

            return Ok(BookAndSearch);
        }
        
        [HttpGet("ByName/{BookAndSearchname}")]
        public IActionResult GetBookAndSearchByName(string BookAndSearchname)
        {
            var BookAndSearch =  _BookAndSearchService.GetBookAndSearchByName(BookAndSearchname);
            return Ok(BookAndSearch);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutBookAndSearch(int Id, BookAndSearch BookAndSearch)
        {
            if (Id != BookAndSearch.Id)
            {
                return BadRequest();
            }

            _context.Entry(BookAndSearch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookAndSearchExists(Id))
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
        public IActionResult CreateBookAndSearch(BookAndSearchDto BookAndSearchDto)
        {
            var BookAndSearch = _BookAndSearchService.CreateBookAndSearch(BookAndSearchDto);
            return Ok(BookAndSearch);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<BookAndSearch>> DeleteBookAndSearch(int Id)
        {
            var BookAndSearch = await _context.BookAndSearches.FindAsync(Id);
            if (BookAndSearch == null)
            {
                return NotFound();
            }

            _context.BookAndSearches.Remove(BookAndSearch);
            await _context.SaveChangesAsync();

            return BookAndSearch;
        }

               private bool BookAndSearchExists(int Id)
        {
            return _context.BookAndSearches.Any(e => e.Id == Id);
        }
    }
}