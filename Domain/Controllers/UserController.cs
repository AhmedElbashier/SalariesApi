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
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUserService _UserService;

        public UserController(AppDbContext context, IUserService UserService)
        {
            _context = context;
            _UserService = UserService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var Users = _UserService.GetALl();
            return Ok(Users);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<User> GetUser(int Id)
        {
            var User = _UserService.GetUser(Id);

            if (User == null)
            {
                return NotFound();
            }

            return Ok(User);
        }
        
        [HttpGet("ByName/{Username}")]
        public IActionResult GetUserByName(string Username)
        {
            var User =  _UserService.GetUserByName(Username);
            return Ok(User);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutUser(int Id, User User)
        {
            if (Id != User.Id)
            {
                return BadRequest();
            }

            _context.Entry(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(Id))
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
        public IActionResult CreateUser(UserDto UserDto)
        {
            var User = _UserService.CreateUser(UserDto);
            return Ok(User);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<User>> DeleteUser(int Id)
        {
            var User = await _context.Users.FindAsync(Id);
            if (User == null)
            {
                return NotFound();
            }

            _context.Users.Remove(User);
            await _context.SaveChangesAsync();

            return User;
        }

               private bool UserExists(int Id)
        {
            return _context.Users.Any(e => e.Id == Id);
        }
    }
}