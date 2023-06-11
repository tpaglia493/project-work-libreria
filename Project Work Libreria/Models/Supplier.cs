namespace Project_Work_Libreria.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AdminPurchaseDataId { get; set; }
        public AdminPurchaseData AdminPurchaseData { get; set; }


        public Supplier() { }
    }
}
