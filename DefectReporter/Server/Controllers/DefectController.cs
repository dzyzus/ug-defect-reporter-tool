namespace DefectReporter.Server.Controllers
{
    #region Usings

    using DefectReporter.Server.Data.Application;
    using DefectReporter.Shared.Models.Application;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    /// The defect controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DefectController : ControllerBase
    {
        /// <summary>
        /// The db context.
        /// </summary>
        private readonly DefectReporterContext _context;

        /// <summary>
        /// The defect controller constructor.
        /// </summary>
        /// <param name="context">
        /// The db context.
        /// </param>
        public DefectController(DefectReporterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The get defects.
        /// </summary>
        /// <returns>
        /// Returns the defect list.
        /// </returns>
        [HttpGet("getDefects")]
        public async Task<List<Defect>> GetDefects()
        {
            return await _context.Defects.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// The create defect.
        /// </summary>
        /// <param name="defect">
        /// The defect model.
        /// </param>
        /// <returns>
        /// Returns action status. 
        /// </returns>
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

        /// <summary>
        /// The delecte action.
        /// </summary>
        /// <param name="defectId">
        /// The defect id.
        /// </param>
        /// <returns>
        /// Returns action status.
        /// </returns>
        [HttpDelete("deleteFeature/{defectId}")]
        public async Task<IActionResult> DeleteDefect(int defectId)
        {
            var feature = await _context.Features.FindAsync(defectId);

            if (feature == null)
            {
                return NotFound($"Defect with ID {defectId} not found");
            }

            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();

            return Ok($"Defect with ID {defectId} deleted successfully");
        }
    }
}
