using Microsoft.EntityFrameworkCore;
using NaukaWebApi.Models;

namespace NaukaWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<Person> People { get; set; }
    }
}
