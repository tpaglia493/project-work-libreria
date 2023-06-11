namespace Project_Work_Libreria.Models
{
    public class AdminPurchaseData
    {
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int Quantity { get; set; }

        public int? PurchasedBookId { get; set; }
        public Book? PurchasedBook { get; set; }

        public int PurchasePrice { get; set; }


        //relazione 1-n con supplier
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public AdminPurchaseData() { }

    }
}
