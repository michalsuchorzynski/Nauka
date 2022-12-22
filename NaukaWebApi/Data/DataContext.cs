using Microsoft.EntityFrameworkCore;
using NaukaWebApi.Models;

namespace NaukaWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=Nauka;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Person> People { get; set; }
    }
}
