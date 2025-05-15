using Microsoft.EntityFrameworkCore;
using TechFolio.Data.Models;


namespace TechFolio.Server.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Goal> Goals { get; set; }
    }
}

