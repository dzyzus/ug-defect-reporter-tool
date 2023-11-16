namespace DefectReporter.Server.Controllers
{
    #region Usings

    using DefectReporter.Server.Data.Application;
    using DefectReporter.Shared.Models.Application;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    /// The feature controller.
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

        /// <summary>
        /// The get feature.
        /// </summary>
        /// <param name="featureId">
        /// The ferature id.
        /// </param>
        /// <returns>
        /// Returns the action status.
        /// </returns>
        [HttpGet("getFeature/{featureId}")]
        public async Task<IActionResult> GetFeature(int featureId)
        {
            var feature = await _context.Features.FindAsync(featureId);

            if (feature == null)
            {
                return NotFound();
            }

            return Ok(feature);
        }

        /// <summary>
        /// The update feature.
        /// </summary>
        /// <param name="featureId">
        /// The feature id.
        /// </param>
        /// <param name="feature">
        /// The feature model.
        /// </param>
        /// <returns>
        /// Returns the action status.
        /// </returns>
        [HttpPut("updateFeature/{featureId}")]
        public async Task<IActionResult> UpdateFeature(int featureId, [FromBody] Feature feature)
        {
            if (featureId != feature.Id)
            {
                return BadRequest();
            }

            _context.Entry(feature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureExists(featureId))
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
        /// The feature exists.
        /// </summary>
        /// <param name="featureId">
        /// The feature id.
        /// </param>
        /// <returns>
        /// Returns value which indicates the feature exists.
        /// </returns>
        private bool FeatureExists(int featureId)
        {
            return _context.Features.Any(e => e.Id == featureId);
        }
    }
}
