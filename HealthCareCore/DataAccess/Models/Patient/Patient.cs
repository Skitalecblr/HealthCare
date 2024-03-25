using HealthCare.Core.DataAccess.Configuration;
using HealthCare.Core.DataAccess.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace HealthCare.Core.DataAccess.Models.Patient
{
    [EntityTypeConfiguration(typeof(PatientEntityTypeConfiguration))]
    public class Patient
    {
        public Guid Id { get; set; }

        public string? Use { get; set; }

        public string Family { get; set; }

        public List<string>? Given { get; set; }

        public Gender? Gender { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime BirthDate { get; set; }

        public bool? Active { get; set; }
    }
}
