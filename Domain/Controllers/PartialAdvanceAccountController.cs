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
    public class PartialAdvanceAccountController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPartialAdvanceAccountService _PartialAdvanceAccountService;

        public PartialAdvanceAccountController(AppDbContext context, IPartialAdvanceAccountService PartialAdvanceAccountService)
        {
            _context = context;
            _PartialAdvanceAccountService = PartialAdvanceAccountService;
        }

        [HttpGet]
        public IActionResult GetPartialAdvanceAccounts()
        {
            var PartialAdvanceAccounts = _PartialAdvanceAccountService.GetALl();
            return Ok(PartialAdvanceAccounts);
        }

        [HttpGet("{Id}")]
        public ActionResult<PartialAdvanceAccount> GetPartialAdvanceAccount(int Id)
        {
            var PartialAdvanceAccount = _PartialAdvanceAccountService.GetPartialAdvanceAccount(Id);

            if (PartialAdvanceAccount == null)
            {
                return NotFound();
            }

            return Ok(PartialAdvanceAccount);
        }

        [HttpGet("ByName/{PartialAdvanceAccountname}")]
        public IActionResult GetPartialAdvanceAccountByName(string PartialAdvanceAccountname)
        {
            var PartialAdvanceAccount = _PartialAdvanceAccountService.GetPartialAdvanceAccountByName(PartialAdvanceAccountname);
            return Ok(PartialAdvanceAccount);
        }
        [HttpGet("ByEmpId/{EmpId}")]
        public IActionResult GetPartialAdvanceAccountByEmpId(string EmpId)
        {
            var PartialAdvanceAccount =  _PartialAdvanceAccountService.GetPartialAdvanceAccountByEmpId(EmpId);
            return Ok(PartialAdvanceAccount);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutPartialAdvanceAccount(int Id, PartialAdvanceAccount PartialAdvanceAccount)
        {
            if (Id != PartialAdvanceAccount.Id)
            {
                return BadRequest();
            }

            _context.Entry(PartialAdvanceAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartialAdvanceAccountExists(Id))
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
        public IActionResult CreatePartialAdvanceAccount(PartialAdvanceAccountDto PartialAdvanceAccountDto)
        {
            var PartialAdvanceAccount = _PartialAdvanceAccountService.CreatePartialAdvanceAccount(PartialAdvanceAccountDto);
            return Ok(PartialAdvanceAccount);
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult<PartialAdvanceAccount>> DeletePartialAdvanceAccount(int Id)
        {
            var PartialAdvanceAccount = await _context.PartialAdvanceAccounts.FindAsync(Id);
            if (PartialAdvanceAccount == null)
            {
                return NotFound();
            }

            _context.PartialAdvanceAccounts.Remove(PartialAdvanceAccount);
            await _context.SaveChangesAsync();

            return PartialAdvanceAccount;
        }

        private bool PartialAdvanceAccountExists(int Id)
        {
            return _context.PartialAdvanceAccounts.Any(e => e.Id == Id);
        }
    }
}