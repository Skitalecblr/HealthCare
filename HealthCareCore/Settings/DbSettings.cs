namespace HealthCare.Core.Settings
{
    public class DbSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        
    }

    public class ConnectionStrings
    {
        public string Api { get; set; }
    }

}
