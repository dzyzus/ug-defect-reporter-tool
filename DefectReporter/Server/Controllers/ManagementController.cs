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
            var feature = await _context.Features.FindAsync(releaseId);

            if (feature == null)
            {
                return NotFound($"Release with ID {releaseId} not found");
            }

            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();

            return Ok($"Release with ID {releaseId} deleted successfully");
        }

        /// <summary>
        /// The delecte action.
        /// </summary>
        /// <param name="softwareBuildId">
        /// The software build id id.
        /// </param>
        /// <returns>
        /// Returns action status.
        /// </returns>
        [HttpDelete("deleteSoftwareBuild/{softwareBuilId}")]
        public async Task<IActionResult> DeleteSoftwareBuild(int softwareBuildId)
        {
            var feature = await _context.Features.FindAsync(softwareBuildId);

            if (feature == null)
            {
                return NotFound($"Software build with ID {softwareBuildId} not found");
            }

            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();

            return Ok($"Software build with ID {softwareBuildId} deleted successfully");
        }
    }
}
