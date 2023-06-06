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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Book modifiedBook)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", modifiedBook);
            }

            using (BookShopContext db = new BookShopContext())
            {
                Book? bookToModify = db.Book.Where(books => books.Id == id).FirstOrDefault();

                if (bookToModify != null)
                {

                    bookToModify.Title = modifiedBook.Title;
                    bookToModify.Author = modifiedBook.Author;
                    bookToModify.Description = modifiedBook.Description;
                    bookToModify.ImgSource = modifiedBook.ImgSource;
                    bookToModify.Price = modifiedBook.Price;

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound("Libro non trovato!");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using (BookShopContext db = new BookShopContext())
            {
                Book? bookToDelete = db.Book.Where(book => book.Id == id).FirstOrDefault();

                if (bookToDelete != null)
                {
                    db.Remove(bookToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound("Libro non trovato!");

                }
            }
        }



    }
}
