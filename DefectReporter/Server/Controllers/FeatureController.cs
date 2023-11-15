using Microsoft.AspNetCore.Mvc;

namespace DefectReporter.Server.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
