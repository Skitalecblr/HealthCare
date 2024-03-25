using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HealthCare.Core.DataAccess.Models.Patient;

namespace HealthCare.Core.DataAccess.Configuration
{
    public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> modelBuilder)
        {
            modelBuilder.Property(p => p.BirthDate).IsRequired();
            modelBuilder.Property(p => p.Family).IsRequired();
        }
    }
}
