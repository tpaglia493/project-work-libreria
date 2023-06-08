using Microsoft.AspNetCore.Mvc;
using Project_Work_Libreria.Database;
using Project_Work_Libreria.Models;

namespace Project_Work_Libreria.Controllers.API_Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PurchaseDataController : ControllerBase
    {


        //GET PURCHASEDATA BY ID (pass ID by URL)
        [HttpGet("{id}")]
        public IActionResult GetPizzaById(int id)
        {
            using (BookShopContext db = new())
            {
                PurchaseData? dataToFind = db.PurchaseData.Where(data => data.Id == id).FirstOrDefault();
                if (dataToFind != null)
                {

                    return Ok(dataToFind);
                }
                else
                {
                    return NotFound();
                }
            }

        }

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
