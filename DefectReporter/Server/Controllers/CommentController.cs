namespace DefectReporter.Server.Controllers
{
    #region Usings

    using DefectReporter.Server.Data.Application;
    using DefectReporter.Shared.Models.Application;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    /// The comment controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        /// <summary>
        /// The db context.
        /// </summary>
        private readonly DefectReporterContext _context;

        /// <summary>
        /// The comment controller constructor.
        /// </summary>
        /// <param name="context">
        /// The db context.
        /// </param>
        public CommentController(DefectReporterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The get comments for a defect.
        /// </summary>
        /// <param name="defectId">
        /// The defect id.
        /// </param>
        /// <returns>
        /// Return the list of comments.
        /// </returns>
        [HttpGet("getComments/{defectId}")]
        public async Task<List<Comment>> GetComments(int defectId)
        {
            return await _context.Comments.Where(comment => comment.DefectId == defectId).ToListAsync();
        }


        /// <summary>
        /// The create comment.
        /// </summary>
        /// <param name="defect">
        /// The defect model.
        /// </param>
        /// <returns>
        /// Returns action status. 
        /// </returns>
        [HttpPost("createComment")]
        public async Task<IActionResult> CreateComment([FromBody] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return Ok("Comment added successfully!");
            }

            return BadRequest("Invalid comment data");
        }
    }
}
