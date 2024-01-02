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
    public class TestController : ControllerBase
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
        public TestController(DefectReporterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The get tests.
        /// </summary>
        /// <returns>
        /// Returns the tests list.
        /// </returns>
        [HttpGet("getTests")]
        public async Task<List<Test>> GetTests()
        {
            return await _context.Tests.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// The create test.
        /// </summary>
        /// <param name="test">
        /// The test model.
        /// </param>
        /// <returns>
        /// Returns action status. 
        /// </returns>
        [HttpPost("createTest")]
        public async Task<IActionResult> CreateTest([FromBody] Test test)
        {
            if (ModelState.IsValid)
            {
                _context.Tests.Add(test);
                await _context.SaveChangesAsync();
                return Ok("Test created successfully!");
            }

            return BadRequest("Invalid defect data");
        }


        /// <summary>
        /// The update test.
        /// </summary>
        /// <param name="testId">
        /// The test id.
        /// </param>
        /// <param name="test">
        /// The test model.
        /// </param>
        /// <returns>
        /// Returns the action status.
        /// </returns>
        [HttpPut("updatetest/{testId}")]
        public async Task<IActionResult> UpdateTest(int testId, [FromBody] Test test)
        {
            if (testId != test.Id)
            {
                return BadRequest();
            }

            _context.Entry(test).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(testId))
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
        /// The delecte action.
        /// </summary>
        /// <param name="testId">
        /// The test id.
        /// </param>
        /// <returns>
        /// Returns action status.
        /// </returns>
        [HttpDelete("deleteTest/{testId}")]
        public async Task<IActionResult> DeleteTest(int testId)
        {
            var test = await _context.Tests.FindAsync(testId);

            if (test == null)
            {
                return NotFound($"Test with ID {testId} not found");
            }

            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();

            return Ok($"Test with ID {testId} deleted successfully");
        }

        /// <summary>
        /// The get features.
        /// </summary>
        /// <returns>
        /// Returns features list.
        /// </returns>
        [HttpGet("getFeatures")]
        public async Task<List<Feature>> GetFeatures()
        {
            return await _context.Features.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// The get test.
        /// </summary>
        /// <param name="testId">
        /// The test id.
        /// </param>
        /// <returns>
        /// Returns the action status.
        /// </returns>
        [HttpGet("getTest/{testId}")]
        public async Task<IActionResult> GetTest(int testId)
        {
            var test = await _context.Tests.FindAsync(testId);

            if (test == null)
            {
                return NotFound();
            }

            return Ok(test);
        }

        /// <summary>
        /// The test exists.
        /// </summary>
        /// <param name="testId">
        /// The feature id.
        /// </param>
        /// <returns>
        /// Returns value which indicates the test exists.
        /// </returns>
        private bool TestExists(int testId)
        {
            return _context.Tests.Any(e => e.Id == testId);
        }
    }
}
