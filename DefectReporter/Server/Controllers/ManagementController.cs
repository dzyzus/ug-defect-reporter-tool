namespace DefectReporter.Server.Controllers
{
    #region Usings

    using DefectReporter.Server.Data.Application;
    using DefectReporter.Shared.Models.Application;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    /// The management controller.
    /// </summary>
    [Route("api/[controller]")]
    public class ManagementController : ControllerBase
    {
        /// <summary>
        /// The db context.
        /// </summary>
        private readonly DefectReporterContext _context;

        /// <summary>
        /// The management controller constructor.
        /// </summary>
        /// <param name="context">
        /// The db context.
        /// </param>
        public ManagementController(DefectReporterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The get releases method.
        /// </summary>
        /// <returns>
        /// Returns list of releases.
        /// </returns>
        [HttpGet("getReleases")]
        public async Task<List<Release>> GetReleases()
        {
            return await _context.Releases.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// The get software builds.
        /// </summary>
        /// <returns>
        /// Returns software builds list.
        /// </returns>
        [HttpGet("getSoftwareBuilds")]
        public async Task<List<SoftwareBuild>> GetSoftwareBuilds()
        {
            return await _context.SoftwareBuilds.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// The add software build.
        /// </summary>
        /// <param name="softwareBuild">
        /// The softwareBuild model.
        /// </param>
        /// <returns>
        /// Returns action status. 
        /// </returns>
        [HttpPost("addSoftwareBuild")]
        public async Task<IActionResult> AddSoftwareBuild([FromBody] SoftwareBuild softwareBuild)
        {
            if (ModelState.IsValid)
            {
                _context.SoftwareBuilds.Add(softwareBuild);
                await _context.SaveChangesAsync();
                return Ok("Software build added successfully!");
            }

            return BadRequest("Invalid software build data");
        }

        /// <summary>
        /// The add release.
        /// </summary>
        /// <param name="release">
        /// The release model.
        /// </param>
        /// <returns>
        /// Returns action status. 
        /// </returns>
        [HttpPost("addRelease")]
        public async Task<IActionResult> AddRelease([FromBody] Release release)
        {
            if (ModelState.IsValid)
            {
                _context.Releases.Add(release);
                await _context.SaveChangesAsync();
                return Ok("Release added successfully!");
            }

            return BadRequest("Invalid release data");
        }

        /// <summary>
        /// The delecte action.
        /// </summary>
        /// <param name="releaseId">
        /// The release id.
        /// </param>
        /// <returns>
        /// Returns action status.
        /// </returns>
        [HttpDelete("deleteRelease/{releaseId}")]
        public async Task<IActionResult> DeleteRelease(int releaseId)
        {
            var release = await _context.Releases.FindAsync(releaseId);

            if (release == null)
            {
                return NotFound($"Release with ID {releaseId} not found");
            }

            _context.Releases.Remove(release);
            await _context.SaveChangesAsync();

            return Ok($"Release with ID {releaseId} deleted successfully");
        }

        /// <summary>
        /// The delecte action.
        /// </summary>
        /// <param name="softwareBuildId">
        /// The software build id.
        /// </param>
        /// <returns>
        /// Returns action status.
        /// </returns>
        [HttpDelete("deleteSoftwareBuild/{softwareBuildId}")]
        public async Task<IActionResult> DeleteSoftwareBuild(int softwareBuildId)
        {
            var softwareBuild = await _context.SoftwareBuilds.FindAsync(softwareBuildId);

            if (softwareBuild == null)
            {
                return NotFound($"Software build with ID {softwareBuildId} not found");
            }

            _context.SoftwareBuilds.Remove(softwareBuild);
            await _context.SaveChangesAsync();

            return Ok($"Software build with ID {softwareBuildId} deleted successfully");
        }

        /// <summary>
        /// The get release.
        /// </summary>
        /// <param name="releaseId">
        /// The release id.
        /// </param>
        /// <returns>
        /// Returns the action status.
        /// </returns>
        [HttpGet("getRelease/{releaseId}")]
        public async Task<IActionResult> GetFeature(int releaseId)
        {
            var release = await _context.Releases.FindAsync(releaseId);

            if (release == null)
            {
                return NotFound();
            }

            return Ok(release);
        }

        /// <summary>
        /// The update release.
        /// </summary>
        /// <param name="releaseId">
        /// The feature id.
        /// </param>
        /// <param name="release">
        /// The release model.
        /// </param>
        /// <returns>
        /// Returns the action status.
        /// </returns>
        [HttpPut("updateRelease/{releaseId}")]
        public async Task<IActionResult> UpdateRelease(int releaseId, [FromBody] Release release)
        {
            if (releaseId != release.Id)
            {
                return BadRequest();
            }

            _context.Entry(release).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReleaseExists(releaseId))
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

        /// <summary>
        /// The release exists.
        /// </summary>
        /// <param name="releaseId">
        /// The release id.
        /// </param>
        /// <returns>
        /// Returns value which indicates the release exists.
        /// </returns>
        private bool ReleaseExists(int releaseId)
        {
            return _context.Releases.Any(e => e.Id == releaseId);
        }

        /// <summary>
        /// The get software build.
        /// </summary>
        /// <param name="softwareBuildId">
        /// The software build id.
        /// </param>
        /// <returns>
        /// Returns the action status.
        /// </returns>
        [HttpGet("getSoftwareBuild/{softwareBuildId}")]
        public async Task<IActionResult> GetSoftwareBuild(int softwareBuildId)
        {
            var softwareBuild = await _context.SoftwareBuilds.FindAsync(softwareBuildId);

            if (softwareBuild == null)
            {
                return NotFound();
            }

            return Ok(softwareBuild);
        }

        /// <summary>
        /// The update software build.
        /// </summary>
        /// <param name="softwareBuildId">
        /// The software build id.
        /// </param>
        /// <param name="softwareBuild">
        /// The software build model.
        /// </param>
        /// <returns>
        /// Returns the action status.
        /// </returns>
        [HttpPut("updateSoftwareBuild/{softwareBuildId}")]
        public async Task<IActionResult> UpdateSoftwareBuild(int softwareBuildId, [FromBody] SoftwareBuild softwareBuild)
        {
            if (softwareBuildId != softwareBuild.Id)
            {
                return BadRequest();
            }

            _context.Entry(softwareBuild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReleaseExists(softwareBuildId))
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

        /// <summary>
        /// The software build exists.
        /// </summary>
        /// <param name="softwareBuildId">
        /// The software build id.
        /// </param>
        /// <returns>
        /// Returns value which indicates the release exists.
        /// </returns>
        private bool SoftwareBuildExists(int softwareBuildId)
        {
            return _context.Releases.Any(e => e.Id == softwareBuildId);
        }
    }
}
