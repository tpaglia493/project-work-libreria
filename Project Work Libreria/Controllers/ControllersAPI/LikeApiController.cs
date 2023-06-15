using Microsoft.AspNetCore.Mvc;
using Project_Work_Libreria.Database;
using Project_Work_Libreria.Models;
using System.Security.Claims;

namespace Project_Work_Libreria.Controllers.ControllersAPI
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class LikeApiController : ControllerBase
	{
		[HttpPost("{id}")]
		public IActionResult AddLike(int id, [FromBody] Like like)
		{

			using (BookShopContext db = new BookShopContext())
			{
				Book likedBook = db.Book.Where(b => b.Id == id).FirstOrDefault();
				string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				likedBook.UsersThatLiked.Add(userId);
				likedBook.LikeQuantity += like.Quantity;
				db.Like.Add(like);
				db.SaveChanges();
				return Ok();
			}



		}

	}
}

