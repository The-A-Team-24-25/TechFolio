using System.Collections.Generic;
using TechFolio.Server.Models;
using Microsoft.EntityFrameworkCore;
using TechFolio.Server.Models;


namespace TechFolio.Server.Data
{
    public class MyProfileDbContext : DbContext
    {
        public MyProfileDbContext(DbContextOptions<MyProfileDbContext> options)
          : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Sanction> Sanctions { get; set; }

    }
}
