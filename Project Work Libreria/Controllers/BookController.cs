using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Work_Libreria.Database;
using Project_Work_Libreria.Models;
using Project_Work_Libreria.Models.ModelForViews;
using System.Data;

namespace Project_Work_Libreria.Controllers
{
    public class BookController : Controller
    {
        //*********************** GET LISTA DI LIBRI CON LA LORO CATEGORIA **************************

        //[Authorize(Roles = "ADMIN,USER")]
        public IActionResult Index()
        {
            using (BookShopContext db = new())
            {
                //TODO: REFACTORING USANDO .include()
                List<BookCategory> bookCategories = db.Categories.ToList();
                List<Book_ListBookCategories> listOfModels = new();
                foreach (Book book in db.Book)
                {
                    Book_ListBookCategories modelForView = new();
                    modelForView.Book = book;
                    modelForView.BookCategories = bookCategories;
                    listOfModels.Add(modelForView);

                }

                return View("Index", listOfModels);
            }
        }

        //******************************* CREARE UN LIBRO ***********************************

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Create()
        {
            using (BookShopContext db = new BookShopContext())
            {
                List<BookCategory> bookCategories = db.Categories.ToList();
                Book_ListBookCategories modelForView = new();
                Book newBook = new Book();
                modelForView.BookCategories = bookCategories;
                modelForView.Book = newBook;
                return View("Create", modelForView);
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book_ListBookCategories data)
        {
            if (!ModelState.IsValid)
            {
                using (BookShopContext db = new BookShopContext())
                {
                    List<BookCategory> bookCategories = db.Categories.ToList();
                    data.BookCategories = bookCategories;

                    return View("Create", data);
                }
            }
            using (BookShopContext db = new BookShopContext())
            {



                db.Book.Add(data.Book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


        }



        //******************************* MODIFICARE UN LIBRO ***********************************

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

        // [Authorize(Roles = "ADMIN")]
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
        //******************************* ELIMINARE UN LIBRO ***********************************

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

        //******************************* DETTAGLI DI UN LIBRO ***********************************
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

    }
}
