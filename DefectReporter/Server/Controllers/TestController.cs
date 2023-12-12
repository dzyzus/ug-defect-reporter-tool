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
                return Ok("Defect created successfully!");
            }

            return BadRequest("Invalid defect data");
        }
    }
}
