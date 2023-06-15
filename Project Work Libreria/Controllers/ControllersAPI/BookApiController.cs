using Microsoft.AspNetCore.Mvc;
using Project_Work_Libreria.Database;
using Project_Work_Libreria.Models;

namespace Project_Work_Libreria.Controllers.ControllersAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookApiController : ControllerBase
    {

        [HttpPut("{id}")]
        public IActionResult AddLike(int id, [FromBody] int data)
        {

            using (BookShopContext db = new BookShopContext())
            {
                Book likedBook = db.Book.Where(b => b.Id == id).FirstOrDefault();

                likedBook.LikeQuantity = (int)data;
                db.SaveChanges();
                return Ok();
            }



        }

    }
}
