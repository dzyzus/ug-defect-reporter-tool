using DefectReporter.Server.Data.Application;
using DefectReporter.Shared.Models.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DefectReporter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DefectController : ControllerBase
    {
        private readonly DefectReporterContext _context;

        public DefectController(ILogger<DefectController> logger, DefectReporterContext context)
        {
            _context = context;
        }

        [HttpGet("getDefects")]
        public async Task<List<Defect>> GetDefects()
        {
            return await _context.Defects.AsNoTracking().ToListAsync();
        }

        [HttpGet("getReleases")]
        public async Task<List<Release>> GetReleases()
        {
            return await _context.Releases.AsNoTracking().ToListAsync();
        }

        [HttpPost("createDefect")]
        public async Task<IActionResult> CreateDefect([FromBody] Defect defect)
        {
            if (ModelState.IsValid)
            {
                _context.Defects.Add(defect);
                await _context.SaveChangesAsync();
                return Ok("Defect created successfully!");
            }

            return BadRequest("Invalid defect data");
        }
    }
}
