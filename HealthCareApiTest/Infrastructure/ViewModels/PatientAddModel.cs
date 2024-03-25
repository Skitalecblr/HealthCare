using HealthCare.ApiTest.Infrastructure.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace HealthCare.ApiTest.Infrastructure.ViewModels
{
    public class PatientNameModelBase
    {
        public string? Use { get; set; }

        public string? Family { get; set; }

        public string[]? Given { get; set; }
    }
    
    public class PatientAddModel
    {
        public virtual PatientNameModelBase? Name { get; set; }
        
        public string? Gender { get; set; }
        
        public string? PatientBirthDate { get; set; }

        public bool? Active { get; set; }

        public PatientAddModel PopulateWithRandomData()
        {
            
            Name = new PatientNameModelBase()
            {
                Use = "Test",
                Family = PopulatorHelper.GetRandomFamily(),
                Given = new [] { PopulatorHelper.GetRandomName(), PopulatorHelper.GetRandomSurname() },
            };
            Gender = PopulatorHelper.GetRandomGender();
            PatientBirthDate = PopulatorHelper.GetRandomDateTime();
            Active = true;

            return this;
        }
    }

    
}
