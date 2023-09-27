using Microsoft.AspNetCore.Mvc;

namespace StoreAplication.Controllers
{
    public class BranchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
