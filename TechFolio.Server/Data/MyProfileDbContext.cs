using System.Collections.Generic;
using TechFolio.Server.Models;
using Microsoft.EntityFrameworkCore;


namespace TechFolio.Server.Data
{
    public class MyProfileDbContext : DbContext
    {
        public MyProfileDbContext(DbContextOptions<MyProfileDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Sanction> Sanctions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                .Property(s => s.ClassName)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
