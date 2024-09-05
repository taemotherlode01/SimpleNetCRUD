using Lecture14.Models;
using Microsoft.EntityFrameworkCore;

namespace Lecture14.Data
{
    public class MvcquizContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public MvcquizContext(DbContextOptions<MvcquizContext> options) : base(options) { }
        public MvcquizContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapping + จัดการ relations
            modelBuilder.Entity<Student>().ToTable("Student");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string server = "localhost";
            string database = "mvcquiz";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";PORT=3306;SslMode=Required;";
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
