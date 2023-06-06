using Microsoft.EntityFrameworkCore;
using Project_Work_Libreria.Models;

namespace Project_Work_Libreria.Database
{
    public class BookShopContext : DbContext
    {

        public DbSet<Book> Book { get; set; }
        public DbSet<BookCategory> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BookShopDB;Integrated Security=True;TrustServerCertificate=True");
        }

    }
}
