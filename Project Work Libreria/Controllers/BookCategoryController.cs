using Microsoft.AspNetCore.Mvc;
using Project_Work_Libreria.Database;
using Project_Work_Libreria.Models;

namespace Project_Work_Libreria.Controllers
{
    public class BookCategoryController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            using (BookShopContext db = new BookShopContext())
            {
                BookCategory data = new();
                return View(data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookCategory data)
        {
            using (BookShopContext db = new BookShopContext())
            {

                BookCategory newCategory = new BookCategory();
                newCategory.Name = data.Name;

                db.Categories.Add(newCategory);
                db.SaveChanges();
                return RedirectToAction("Index", "Book");
            }


        }
    }
}
