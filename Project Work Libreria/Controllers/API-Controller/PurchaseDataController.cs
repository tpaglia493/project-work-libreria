using Microsoft.AspNetCore.Mvc;
using Project_Work_Libreria.Database;
using Project_Work_Libreria.Models;

namespace Project_Work_Libreria.Controllers.API_Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PurchaseDataController : ControllerBase
    {
        [HttpPost("{Id}")]
        public IActionResult CreatePurchaseData(int id, [FromBody] PurchaseData data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                using (BookShopContext db = new BookShopContext())
                {


                    data.PurchasedBook = db.Book.Where(book => book.Id == id).FirstOrDefault();

                    db.PurchaseData.Add(data);
                    db.SaveChanges();
                    return Ok();


                }
            }
        }

    }
}
