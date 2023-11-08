using DefectReporter.Server.Data.Application;
using DefectReporter.Shared.Models.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefectReporter.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DefectController : ControllerBase
    {
        private readonly ILogger<DefectController> _logger;

        private readonly DefectReporterContext _context;

        public DefectController(ILogger<DefectController> logger, DefectReporterContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("api/defects")]
        public IEnumerable<Defect> GetDefects()
        {
            return _context.Defects.Select(defect => defect).ToArray();
        }

        [HttpGet("api/releases")]
        public List<Release> GetReleases()
        {
            return _context.Releases.Select(release => release).ToList();
        }
    }
}
