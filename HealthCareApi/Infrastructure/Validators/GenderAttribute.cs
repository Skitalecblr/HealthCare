using HealthCare.Api.Infrastructure.Helpers;
using HealthCare.Core.DataAccess.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.Infrastructure.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class GenderAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var gender = (string)value;
            if (string.IsNullOrWhiteSpace(gender))
                return true;
            
            return EnumsHelper.GetEnumDescriptions<Gender>().Contains(gender, StringComparer.InvariantCultureIgnoreCase);
        }
    }
}
