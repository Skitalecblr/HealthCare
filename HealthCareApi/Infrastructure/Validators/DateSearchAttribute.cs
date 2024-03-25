using HealthCare.Api.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HealthCare.Api.Infrastructure.Validators
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field, AllowMultiple = false)]
    public class DateSearchAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is not string[] validationValues)
                return false;

            if (!validationValues.Any())
                return false;

            foreach (var dateStr in validationValues)
            {
                if (!Regex.IsMatch(dateStr, HealthCareConstants.RegularExpressions.SearchDateRegex))
                    return false;
            }

            return true;
        }
    }
}
