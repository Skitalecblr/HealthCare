using HealthCare.Api.Infrastructure.Constants;
using HealthCare.Core.DataAccess.Models.Patient;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.ViewModels
{
    public class PatientEditModel : PatientAddModel
    {
        public PatientEditModel() 
        {
           
        }

        public PatientEditModel(Patient patient) : base(patient)
        {
            Id = patient.Id;
        }

        [Required(ErrorMessage = "Id is required")]
        [RegularExpression(HealthCareConstants.RegularExpressions.GuidRegex, ErrorMessage = "Cannot use default Guid")]
        public Guid Id { get; set; }
    
        public override Patient ToEntity()
        {
            var result = base.ToEntity();
            result.Id = Id;
            
            return result;
        }
    }
}
