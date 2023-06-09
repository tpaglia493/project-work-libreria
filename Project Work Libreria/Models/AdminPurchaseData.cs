﻿using System.ComponentModel.DataAnnotations;

namespace Project_Work_Libreria.Models
{
    public class AdminPurchaseData
    {
        public int Id { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public int? PurchasedBookId { get; set; }
        public Book? PurchasedBook { get; set; }
        [Required]
        public int PurchasePrice { get; set; }


        //relazione 1-n con supplier
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public AdminPurchaseData() { }

    }
}
