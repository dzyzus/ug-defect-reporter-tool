using Microsoft.AspNetCore.Mvc;

namespace DefectReporter.Server.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
