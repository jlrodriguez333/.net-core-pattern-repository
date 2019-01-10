using HCDirectory.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace HCDirectory.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Specialty> Specialtys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialty>().ToTable("Specialty");
        }
    }
}
