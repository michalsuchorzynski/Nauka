using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NaukaWebApi.Models;
using System.Reflection.Metadata;

namespace NaukaWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property<DateTime>("ModifyDate");
            }

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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry> modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified );
            if (modifiedEntries != null)
            {
                foreach (EntityEntry item in modifiedEntries)
                {
                    item.Property("ModifyDate").CurrentValue = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Passport> Passports { get; set; }

        public DbSet<PersonCompany> PersonCompanies { get; set; }
    }
}
