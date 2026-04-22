using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students => Set<Student>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tell EF Core how to store Value Objects
            modelBuilder.Entity<Student>().OwnsOne(s => s.Email, e => e.Property(x => x.Value).HasColumnName("Email"));
            modelBuilder.Entity<Student>().OwnsOne(s => s.Grade, g => g.Property(x => x.Value).HasColumnName("Grade"));


            modelBuilder.Entity<Student>().OwnsOne(s => s.Address, address =>
            {
                address.Property(a => a.Street)
                       .HasColumnName("Address_Street");

                address.Property(a => a.City)
                       .HasColumnName("Address_City");

                address.Property(a => a.ZipCode)
                       .HasColumnName("Address_ZipCode");
            });
        }
    }
}
