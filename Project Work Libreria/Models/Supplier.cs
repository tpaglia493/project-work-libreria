namespace Project_Work_Libreria.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }

       

        public List<AdminPurchaseData>? AdminPurchaseDatas { get; set; }

        public Supplier() { }
    }
}
