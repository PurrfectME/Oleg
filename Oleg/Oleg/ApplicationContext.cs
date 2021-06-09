using Microsoft.EntityFrameworkCore;
using Oleg.Entities;

namespace Oleg
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public ApplicationContext() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=D-YAFREMAU\MS17MONOLITHSQL;Database=Diploma;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Theme>()
                .HasIndex(u => u.Title)
                .IsUnique();
        }
    }
}
