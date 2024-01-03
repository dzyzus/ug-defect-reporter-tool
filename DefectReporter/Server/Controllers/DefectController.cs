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
        /// The get defect details.
        /// </summary>
        /// <param name="defectId">
        /// The defect id.
        /// </param>
        /// <returns>
        /// Return the defect model.
        /// </returns>
        [HttpGet("getDefectDetails/{defectId}")]
        public async Task<Defect> GetDefectDetails(int defectId)
        {
            return await _context.Defects.Where(defect => defect.Id == defectId).FirstOrDefaultAsync();
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
        [HttpDelete("deleteDefect/{defectId}")]
        public async Task<IActionResult> DeleteDefect(int defectId)
        {
            var defect = await _context.Defects.FindAsync(defectId);

            if (defect == null)
            {
                return NotFound($"Defect with ID {defectId} not found");
            }

            _context.Defects.Remove(defect);
            await _context.SaveChangesAsync();

            return Ok($"Defect with ID {defectId} deleted successfully");
        }

        /// <summary>
        /// The update feature.
        /// </summary>
        /// <param name="defectId">
        /// The feature id.
        /// </param>
        /// <param name="defect">
        /// The feature model.
        /// </param>
        /// <returns>
        /// Returns the action status.
        /// </returns>
        [HttpPut("updateDefect/{defectId}")]
        public async Task<IActionResult> UpdateDefect(int defectId, [FromBody] Defect defect)
        {
            if (defectId != defect.Id)
            {
                return BadRequest();
            }

            _context.Entry(defect).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefectExists(defectId))
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
        /// The defect exists.
        /// </summary>
        /// <param name="defectId">
        /// The defect id.
        /// </param>
        /// <returns>
        /// Returns value which indicates the defect exists.
        /// </returns>
        private bool DefectExists(int defectId)
        {
            return _context.Defects.Any(e => e.Id == defectId);
        }
    }
}
