using Microsoft.AspNetCore.Mvc;
using Project_Work_Libreria.Database;
using Project_Work_Libreria.Models;

namespace Project_Work_Libreria.Controllers.ControllersAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminPurchaseDataApiController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] AdminPurchaseData AdminPurchaseData)
        {

            using (BookShopContext db = new BookShopContext())
            {
                int BookId = (int)AdminPurchaseData.PurchasedBookId;
                Book purchasedBook = db.Book.Where(book => book.Id == BookId).FirstOrDefault();
                purchasedBook.AvailableCopies -= AdminPurchaseData.Quantity;
                db.AdminPurchaseDatas.Add(AdminPurchaseData);
                db.SaveChanges();

            }


            return CreatedAtAction(nameof(Create), new { id = AdminPurchaseData.Id }, AdminPurchaseData);
        }
    }
}
