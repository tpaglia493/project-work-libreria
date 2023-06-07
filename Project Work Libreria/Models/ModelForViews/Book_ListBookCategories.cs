namespace Project_Work_Libreria.Models.ModelForViews
{
    public class Book_ListBookCategories
    {
        public Book? BookForRelation { get; set; }
        public List<BookCategory>? BookCategories { get; set; }

        public PurchaseData? purchaseData { get; set; }
    }
}
