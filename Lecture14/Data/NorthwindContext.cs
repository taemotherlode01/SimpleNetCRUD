using Lecture14.Models;
using Microsoft.EntityFrameworkCore;

namespace Lecture14.Data
{
    public class NorthwindContext : DbContext
    {
        //Constructor
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options) { }

        public NorthwindContext() { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mapping + จัดการ relations
            modelBuilder.Entity<Product>().ToTable("Products");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string server = "localhost";
            string database = "northwind";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";PORT=3306;SslMode=Required;";
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
