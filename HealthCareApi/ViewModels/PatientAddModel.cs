using HealthCare.Api.Infrastructure.Constants;
using HealthCare.Api.Infrastructure.Validators;
using HealthCare.Core.DataAccess.Models.Enums;
using HealthCare.Core.DataAccess.Models.Patient;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.ViewModels
{
    public class PatientNameModelBase
    {
        public PatientNameModelBase() 
        {
            Given = new List<string>();
            Family = string.Empty;
        }
        
        public string? Use { get; set; }

        public string? Family { get; set; }

        public List<string> Given { get; set; }
    }
    
    public class PatientAddModel
    {
        public PatientAddModel()
        {
            Name = new PatientNameModelBase();
        }

        public PatientAddModel(Patient patient)
        {
            Name = new PatientNameModelBase()
            {
                Family = patient.Family,
                Given = patient.Given,
                Use = patient.Use
            };
            
            Gender = patient.Gender.ToString();
            PatientBirthDate = patient.BirthDate.ToString(HealthCareConstants.Formats.StandardXmlDateTime);
            Active = patient.Active;
        }
        
        public virtual PatientNameModelBase Name { get; set; }

        [Gender(ErrorMessage = "Gender is invalid. Available values are  [ male | female | other | unknown ]")]
        public string? Gender { get; set; }
        
        [RegularExpression(HealthCareConstants.RegularExpressions.DateTimeRegex, ErrorMessage = "The Birth Date is incorrect format")]
        public string? PatientBirthDate { get; set; }

        public bool? Active { get; set; }

        public virtual Patient ToEntity()
        {
            return new Patient()
            {
                 Active = Active,
                 Gender = string.IsNullOrWhiteSpace(Gender) ? Core.DataAccess.Models.Enums.Gender.Unknown : (Gender)Enum.Parse(typeof(Gender), Gender, true),
                 BirthDate = DateTime.Parse(PatientBirthDate), //Should be always converted, because validation step exists
                 Family = Name.Family,
                 Given = Name.Given,
                 Use = Name.Use
            };
        }
    }
}
