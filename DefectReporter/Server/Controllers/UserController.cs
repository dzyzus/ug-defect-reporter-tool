namespace DefectReporter.Server.Controllers
{
    #region Usings

    using DefectReporter.Shared.Models.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    #endregion

    /// <summary>
    /// The user controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("getUsers")]
        public ActionResult<IEnumerable<ApplicationUser>> GetUsers()
        {
            var users = _userManager.Users.ToList();
            return users;
        }
    }
}
