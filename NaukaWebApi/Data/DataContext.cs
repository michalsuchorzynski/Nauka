using Microsoft.EntityFrameworkCore;
using NaukaWebApi.Models;

namespace NaukaWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>()
                .HasOne(p => p.Person)
                .WithMany(p => p.Phones)
                .HasForeignKey(p => p.PersonId);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Passport)
                .WithOne(p => p.Person)
                .HasForeignKey<Passport>(p => p.PersonId);

            modelBuilder.Entity<PersonCompany>()
                .HasKey(pc => new { pc.PersonId, pc.CompanyId });
            modelBuilder.Entity<PersonCompany>()
                .HasOne(pc => pc.Person)
                .WithMany(p => p.PersonCompanies)
                .HasForeignKey(pc => pc.PersonId);
            modelBuilder.Entity<PersonCompany>()
                .HasOne(pc => pc.Company)
                .WithMany(c => c.PersonCompanies)
                .HasForeignKey(pc => pc.CompanyId);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Passport> Passports { get; set; }

        public DbSet<PersonCompany> PersonCompanies { get; set; }
    }
}
