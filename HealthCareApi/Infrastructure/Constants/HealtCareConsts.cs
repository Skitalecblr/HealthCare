namespace HealthCare.Api.Infrastructure.Constants
{
    public static class HealthCareConstants
    {
        public static class RegularExpressions
        {
            public const string DateTimeRegex = @"([0-9]([0-9]([0-9][1-9]|[1-9]0)|[1-9]00)|[1-9]000)(-(0[1-9]|1[0-2])(-(0[1-9]|[1-2][0-9]|3[0-1])(T([01][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)(\.[0-9]{1,9})?)?)?(Z|(\+|-)((0[0-9]|1[0-3]):[0-5][0-9]|14:00)?)?)?";
            public const string GuidRegex = "^((?!00000000-0000-0000-0000-000000000000).)*$";
            public const string SearchDateRegex = @"^(eq|ne|gt|lt|ge|le|sa|eb|ap)\d{4}-\d{2}-\d{2}(T\d{2}:\d{2}:\d{2}(\.\d{1,3})?Z)?$";
        }

        public static class Formats
        {
            public const string StandardXmlDateTime = "yyyy-MM-ddTHH:mm:ss.fffZ";
        }
    }
}
