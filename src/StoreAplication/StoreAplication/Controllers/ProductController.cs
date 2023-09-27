using Microsoft.AspNetCore.Mvc;

namespace StoreAplication.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
