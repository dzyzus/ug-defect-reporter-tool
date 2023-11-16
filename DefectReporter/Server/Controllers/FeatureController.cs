namespace DefectReporter.Server.Controllers
{
    #region Usings

    using DefectReporter.Server.Data.Application;
    using DefectReporter.Shared.Models.Application;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    /// The test controller.
    /// </summary>
    [Route("api/[controller]")]
    public class FeatureController : ControllerBase
    {
        /// <summary>
        /// The db context.
        /// </summary>
        private readonly DefectReporterContext _context;

        /// <summary>
        /// The feature controller constructor.
        /// </summary>
        /// <param name="context">
        /// The db context.
        /// </param>
        public FeatureController(DefectReporterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The get features.
        /// </summary>
        /// <returns>
        /// Returns the features list.
        /// </returns>
        [HttpGet("getFeatures")]
        public async Task<List<Feature>> GetFeatures()
        {
            return await _context.Features.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// The create feature.
        /// </summary>
        /// <param name="feature">
        /// The feature model.
        /// </param>
        /// <returns>
        /// Returns action status. 
        /// </returns>
        [HttpPost("createFeature")]
        public async Task<IActionResult> CreateFeature([FromBody] Feature feature)
        {
            if (ModelState.IsValid)
            {
                _context.Features.Add(feature);
                await _context.SaveChangesAsync();
                return Ok("Defect created successfully!");
            }

            return BadRequest("Invalid feature data");
        }

        /// <summary>
        /// The delecte action.
        /// </summary>
        /// <param name="featureId">
        /// The feature id.
        /// </param>
        /// <returns>
        /// Returns action status.
        /// </returns>
        [HttpDelete("deleteFeature/{featureId}")]
        public async Task<IActionResult> DeleteFeature(int featureId)
        {
            var feature = await _context.Features.FindAsync(featureId);

            if (feature == null)
            {
                return NotFound($"Feature with ID {featureId} not found");
            }

            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();

            return Ok($"Feature with ID {featureId} deleted successfully");
        }
    }
}
