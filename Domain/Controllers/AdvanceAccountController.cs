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
    public class AdvanceAccountController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAdvanceAccountService _AdvanceAccountService;

        public AdvanceAccountController(AppDbContext context, IAdvanceAccountService AdvanceAccountService)
        {
            _context = context;
            _AdvanceAccountService = AdvanceAccountService;
        }

        [HttpGet]
        public IActionResult GetAdvanceAccounts()
        {
            var AdvanceAccounts = _AdvanceAccountService.GetALl();
            return Ok(AdvanceAccounts);
        }

        [HttpGet("{Id}")]
        public ActionResult<AdvanceAccount> GetAdvanceAccount(int Id)
        {
            var AdvanceAccount = _AdvanceAccountService.GetAdvanceAccount(Id);

            if (AdvanceAccount == null)
            {
                return NotFound();
            }

            return Ok(AdvanceAccount);
        }

        [HttpGet("ByName/{AdvanceAccountname}")]
        public IActionResult GetAdvanceAccountByName(string AdvanceAccountname)
        {
            var AdvanceAccount = _AdvanceAccountService.GetAdvanceAccountByName(AdvanceAccountname);
            return Ok(AdvanceAccount);
        }
        [HttpGet("ByEmpId/{EmpId}")]
        public IActionResult GetAdvanceAccountByEmpId(string EmpId)
        {
            var AdvanceAccount =  _AdvanceAccountService.GetAdvanceAccountByEmpId(EmpId);
            return Ok(AdvanceAccount);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutAdvanceAccount(int Id, AdvanceAccount AdvanceAccount)
        {
            if (Id != AdvanceAccount.Id)
            {
                return BadRequest();
            }

            _context.Entry(AdvanceAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvanceAccountExists(Id))
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
        public IActionResult CreateAdvanceAccount(AdvanceAccountDto AdvanceAccountDto)
        {
            var AdvanceAccount = _AdvanceAccountService.CreateAdvanceAccount(AdvanceAccountDto);
            return Ok(AdvanceAccount);
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult<AdvanceAccount>> DeleteAdvanceAccount(int Id)
        {
            var AdvanceAccount = await _context.AdvanceAccounts.FindAsync(Id);
            if (AdvanceAccount == null)
            {
                return NotFound();
            }

            _context.AdvanceAccounts.Remove(AdvanceAccount);
            await _context.SaveChangesAsync();

            return AdvanceAccount;
        }

        private bool AdvanceAccountExists(int Id)
        {
            return _context.AdvanceAccounts.Any(e => e.Id == Id);
        }
    }
}