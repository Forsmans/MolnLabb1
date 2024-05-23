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
            var connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Labb1AdminMoln;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            var connectionString = Environment.GetEnvironmentVariable("CVdbConnectionString");
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
