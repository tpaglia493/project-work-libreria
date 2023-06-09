﻿
using System.ComponentModel.DataAnnotations;


namespace Project_Work_Libreria.Models
{
	public class Book
	{
		public int Id { get; set; }
		[Required]
		public string ImgSource { get; set; }
		[Required]
		[StringLength(100, ErrorMessage = "Il titolo non può essere più lungo di 100 caratteri!")]
		public string Title { get; set; }
		[Required]
		[StringLength(100, ErrorMessage = "Il nome dell'autore non può essere più lungo di 100 caratteri!")]
		public string Author { get; set; }
		[Required]
		[StringLength(800, ErrorMessage = "La descirizione non può essere più lunga di 800 caratteri!")]

		public string Description { get; set; }
		[Required]
		[Range(0, float.MaxValue)]
		public float Price { get; set; }

		public int? PurchaseQuantity { get; set; }

		public int? LikeQuantity { get; set; }

		//TODO: INSERIRE DATA-VALIDATIONS
		public float? SupplierPrice { get; set; }

		[Range(0, int.MaxValue)]
		public int? AvailableCopies { get; set; }

		// IMPOSTAZIONE RELAZIONE 1-N CON CATEGORIA
		public int? BookCategoryId { get; set; }
		public BookCategory? Category { get; set; }



		// IMPOSTAZIONE RELAZIONE N-1 CON PURCHASEDATA  
		public List<PurchaseData>? PurchaseDatas { get; set; }




		// IMPOSTAZIONE RELAZIONE N-1 CON ADMINPURCHASEDATA  
		public List<AdminPurchaseData>? AdminPurchaseDatas { get; set; }

		public Book() { }

		public Book(string imgSource, string title, string author, string description, float price, int? availableCopies)
		{

			ImgSource = imgSource;
			Title = title;
			Author = author;
			Description = description;
			Price = price;
			AvailableCopies = availableCopies;
		}
	}
}
