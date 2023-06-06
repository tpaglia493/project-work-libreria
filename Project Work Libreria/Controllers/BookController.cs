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

        [HttpGet]
        public IActionResult Create()
        {
            using (BookShopContext db = new BookShopContext())
            {
                Book newBook = new Book();
                return View("Create", newBook);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book newBook)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newBook);
            }

            using (BookShopContext db = new BookShopContext())
            {
                db.Book.Add(newBook);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (BookShopContext db = new BookShopContext())
            {
                Book? bookToModify = db.Book.Where(book => book.Id == id).FirstOrDefault();

                if (bookToModify != null)
                {
                    return View("Update", bookToModify);
                }
                else
                {

                    return NotFound("Articolo da modifcare inesistente!");
                }
            }
        }
    }
}
