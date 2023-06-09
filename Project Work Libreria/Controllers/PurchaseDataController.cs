﻿using Microsoft.AspNetCore.Mvc;
using Project_Work_Libreria.Database;
using Project_Work_Libreria.Models;
using Project_Work_Libreria.Models.ModelForViews;

namespace Project_Work_Libreria.Controllers
{
    public class PurchaseDataController : Controller
    {
        [HttpGet]
        public IActionResult Create(int id)
        {
            using (BookShopContext db = new BookShopContext())
            {
                PurchaseData data = new();
                Book book = db.Book.Where(book => book.Id == id).FirstOrDefault();
                PurchaseData_Book modelForView = new();
                modelForView.Book = book;
                modelForView.PurchaseData = data;



                return View(modelForView);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PurchaseData_Book modelForView)
        {
            using (BookShopContext db = new BookShopContext())
            {
                db.PurchaseData.Add(modelForView.PurchaseData);
                db.SaveChanges();
                return RedirectToAction("Index", "Book");
            }


        }


    }
}
