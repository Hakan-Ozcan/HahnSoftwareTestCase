using Microsoft.AspNetCore.Mvc;

namespace WebApiSection.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
