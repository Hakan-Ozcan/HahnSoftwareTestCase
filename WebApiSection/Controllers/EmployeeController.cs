using Microsoft.AspNetCore.Mvc;

namespace WebApiSection.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
