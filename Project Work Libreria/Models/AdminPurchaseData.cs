namespace Project_Work_Libreria.Models
{
    public class AdminPurchaseData
    {
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int Quantity { get; set; }

        public int? PurchasedBookId { get; set; }
        public Book? PurchasedBook { get; set; }

        public string Supplier { get; set; }

        public int PurchasePrice { get; set; }

        public AdminPurchaseData() { }

    }
}
