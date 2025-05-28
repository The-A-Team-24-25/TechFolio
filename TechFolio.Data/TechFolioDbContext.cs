using Microsoft.EntityFrameworkCore;
using TechFolio.Data.Models;

namespace TechFolio.Data
{
    public class TechFolioDbContext : DbContext
    {
        public TechFolioDbContext(DbContextOptions<TechFolioDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  Свързване между Project и Student (FK)
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Student)
                .WithMany(s => s.Projects)
                .HasForeignKey(p => p.StudentId);

            // Seed данни (примерен ученик и проект)
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Георги",
                    LastName = "Георгиев",
                    Grade = "11Б",
                    Specialty = "Системно програмиране",
                    Picture = ""
                }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Title = "AI Асистент",
                    Description = "Софтуер за автоматизирано отговаряне на въпроси.",
                    Technologies = "C#, OpenAI, Blazor",
                    FileUrl = "https://example.com/ai-project.zip",
                    StudentId = 1
                }
            );
        }
    }
}
