using HealthCare.Core.DataAccess.Models.Patient;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Core.DataAccess.Context
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient[]
                {
                    new Patient
                    {
                        Id = Guid.NewGuid(),
                        Active = true,
                        BirthDate = DateTime.Now,
                        Family = "Test Patient",
                        Gender = Models.Enums.Gender.Other,
                        Given = new List<string>() { "Test1", "Test2"},
                        Use = "Test"
                    }
                });
        }
    }
}
