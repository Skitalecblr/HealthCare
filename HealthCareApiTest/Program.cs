using HealthCare.ApiTest.Infrastructure.Helpers;
using HealthCare.ApiTest.Infrastructure.ViewModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HealthCare.ApiTest
{
    internal class Program
    {
        private const string ApiKey = "AppSettings:HealthCareApi";
        private const int PatientsCount = 100;

        static async Task Main(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string api = configuration[ApiKey];
            if (string.IsNullOrWhiteSpace(api))
            {
                Console.WriteLine("Api config initialization failed");
                return;
            }

            try
            {
                for (int i = 0; i < PatientsCount; i++)
                {
                    var patient = new PatientAddModel().PopulateWithRandomData();
                    var patientJson = JsonConvert.SerializeObject(patient);
                    await ApiHelper.SendPostRequest(api, patientJson);
                    Console.WriteLine($"Patient {patientJson} has ben added");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something wrong: {ex.Message}");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}