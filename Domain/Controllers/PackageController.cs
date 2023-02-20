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
    public class PackageController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPackageService _PackageService;

        public PackageController(AppDbContext context, IPackageService PackageService)
        {
            _context = context;
            _PackageService = PackageService;
        }

        [HttpGet]
        public IActionResult GetPackages()
        {
            var Packages = _PackageService.GetALl();
            return Ok(Packages);
        }
        
        [HttpGet("{Id}")]
        public ActionResult<Package> GetPackage(int Id)
        {
            var Package = _PackageService.GetPackage(Id);

            if (Package == null)
            {
                return NotFound();
            }

            return Ok(Package);
        }
        
        [HttpGet("ByName/{Packagename}")]
        public IActionResult GetPackageByName(string Packagename)
        {
            var Package =  _PackageService.GetPackageByName(Packagename);
            return Ok(Package);
        }

            [HttpPut("{Id}")]
        public async Task<IActionResult> PutPackage(int Id, Package Package)
        {
            if (Id != Package.Id)
            {
                return BadRequest();
            }

            _context.Entry(Package).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(Id))
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
        public IActionResult CreatePackage(PackageDto PackageDto)
        {
            var Package = _PackageService.CreatePackage(PackageDto);
            return Ok(Package);
        }

       
     [HttpDelete("{Id}")]
        public async Task<ActionResult<Package>> DeletePackage(int Id)
        {
            var Package = await _context.Packages.FindAsync(Id);
            if (Package == null)
            {
                return NotFound();
            }

            _context.Packages.Remove(Package);
            await _context.SaveChangesAsync();

            return Package;
        }

               private bool PackageExists(int Id)
        {
            return _context.Packages.Any(e => e.Id == Id);
        }
    }
}