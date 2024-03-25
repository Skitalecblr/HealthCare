using System.ComponentModel;

namespace HealthCare.Core.DataAccess.Models.Enums
{
    public enum Gender
    {
        [Description("Male")]
        Male = 1,
        [Description("Female")]
        Female = 2,
        [Description("Other")]
        Other = 3,
        [Description("Unknown")]
        Unknown = 4
    }
}
