using Microsoft.AspNetCore.Mvc;

namespace Project_Work_Libreria.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
