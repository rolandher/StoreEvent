using Microsoft.AspNetCore.Mvc;

namespace StoreAplication.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
