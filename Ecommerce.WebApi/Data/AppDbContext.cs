using Ecommerce.Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Ecommerce.WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //// connect database method 1
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Appdata;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;");
        //}
    }
}
