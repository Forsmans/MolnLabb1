using CV.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CV.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<About> About { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connection = "Server=localhost,1433;Database=MolnAdminLabb1;User Id=SA;Password=Ruddalen2022;TrustServerCertificate=True;";
            //var connectionString = Environment.GetEnvironmentVariable("CVdbConnectionString");
            //optionsBuilder.UseSqlServer(optionsBuilder);
        }
    }
}
