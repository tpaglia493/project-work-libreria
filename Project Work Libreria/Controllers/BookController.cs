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


		public IActionResult Index()
		{
			using (BookShopContext db = new BookShopContext())
			{

				List<Book> ourBook = db.Book.Include(b => b.Category).ToList();
				ourBook = db.Book.Include(b => b.PurchaseDatas).ToList();
				return View(ourBook);
			}
		}
		//******************************* CREARE UN LIBRO ***********************************//

		[Authorize(Roles = "ADMIN")]
		[HttpGet]
		public IActionResult Create()
		{
			using (BookShopContext db = new BookShopContext())
			{
				List<BookCategory> bookCategories = db.Categories.ToList();
				Book_ListBookCategories modelForView = new();
				List<PurchaseData> purchaseDatas = new List<PurchaseData>();
				Book newBook = new Book();
				modelForView.BookCategories = bookCategories;
				modelForView.Book = newBook;
				modelForView.Book.PurchaseDatas = purchaseDatas;
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

				data.Book.LikeQuantity = 0;

				db.Book.Add(data.Book);
				db.SaveChanges();
				return RedirectToAction("Admin");
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
				Book_ListBookCategories model = new Book_ListBookCategories();
				model.Book = bookToModify;
				List<BookCategory> bookCategories = db.Categories.ToList();
				model.BookCategories = bookCategories;

				if (bookToModify != null)
				{
					return View("Update", model);
				}
				else
				{



					return View(model);



				}
			}
		}

		[Authorize(Roles = "ADMIN")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(int id, Book_ListBookCategories modifiedBook)
		{
			if (!ModelState.IsValid)
			{
				using (BookShopContext db = new BookShopContext())
				{
					List<BookCategory> categories = db.Categories.ToList();
					modifiedBook.BookCategories = categories;
					return View("Update", modifiedBook);
				}
			}

			using (BookShopContext db = new BookShopContext())
			{
				Book? bookToModify = db.Book.Where(books => books.Id == id).FirstOrDefault();

				if (bookToModify != null)
				{

					bookToModify.Title = modifiedBook.Book.Title;
					bookToModify.Author = modifiedBook.Book.Author;
					bookToModify.Description = modifiedBook.Book.Description;
					bookToModify.ImgSource = modifiedBook.Book.ImgSource;
					bookToModify.Price = modifiedBook.Book.Price;

					db.SaveChanges();
					return RedirectToAction("Admin");

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
				List<PurchaseData> purchaseData = db.PurchaseData.ToList();
				List<AdminPurchaseData> adminPurchaseData = db.AdminPurchaseDatas.ToList();
				Book? bookToDelete = db.Book.Where(book => book.Id == id).FirstOrDefault();
				List<PurchaseData> purchaseDataToRemove = purchaseData.Where(data => data.PurchasedBookId == id).ToList();
				List<AdminPurchaseData> adminPurchaseDataToRemove = adminPurchaseData.Where(data => data.PurchasedBookId == id).ToList();

				if (bookToDelete != null)
				{
					db.Remove(bookToDelete);
					foreach (PurchaseData data in purchaseDataToRemove)
					{
						db.PurchaseData.Remove(data);
					}
					foreach (AdminPurchaseData data in adminPurchaseDataToRemove)
					{
						db.AdminPurchaseDatas.Remove(data);
					}
					db.SaveChanges();

					return RedirectToAction("Admin");

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

		//*********************** GET VIEW ADMIN CON LISTA DI LIBRI E LORO CATEGORIA **************************

		//[Authorize(Roles = "ADMIN,USER")]
		public IActionResult Admin()
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

				return View("Admin", listOfModels);
			}
		}
		//*********************** AGGIUNGERE UN LIKE **************************
		public IActionResult AddLike(int id)
		{

			using (BookShopContext db = new BookShopContext())
			{
				Book likedBook = db.Book.Where(b => b.Id == id).FirstOrDefault();
				likedBook.LikeQuantity += +1;
				db.SaveChanges();
				return RedirectToAction("Index", "Book");
			}

		}
	}
}
