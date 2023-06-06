using Microsoft.AspNetCore.Mvc;
using Project_Work_Libreria.Database;
using Project_Work_Libreria.Models;

namespace Project_Work_Libreria.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            using (BookShopContext db = new BookShopContext())
            {
                List<Book> books = db.Book.ToList<Book>();
                return View("Index", books);
            }
        }


    }
}
