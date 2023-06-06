using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Work_Libreria.Database;
using Project_Work_Libreria.Models;
using System.Data;

namespace Project_Work_Libreria.Controllers
{
    public class BookController : Controller
    {
        [Authorize(Roles = "ADMIN,USER")]
        public IActionResult Index()
        {
            using (BookShopContext db = new BookShopContext())
            {
                List<Book> books = db.Book.ToList<Book>();
                return View("Index", books);
            }
        }


        public IActionResult Details(int id)
        {
            using (BookShopContext db = new BookShopContext())

            {
                Book? bookDetails = db.Book.Where(book => book.Id == id).Include(book => book.Category).FirstOrDefault();



                if (bookDetails != null)
                {
                    return View("Details", bookDetails);
                }
                else
                {
                    return NotFound($"L'articolo con id {id} non è stato trovato!");
                }



            }

        }



        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Create()
        {
            using (BookShopContext db = new BookShopContext())
            {
                Book newBook = new Book();
                return View("Create", newBook);
            }
        }

        [Authorize(Roles = "ADMIN")]
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

        [Authorize(Roles = "ADMIN")]
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

        [Authorize(Roles = "ADMIN")]
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

        [Authorize(Roles = "ADMIN")]
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
