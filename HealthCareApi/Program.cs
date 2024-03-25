using HealthCare.Core.DataAccess.Context;
using HealthCare.Core.Services;
using HealthCare.Core.Services.Interfaces;
using HealthCare.Core.Settings;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.UseUrls("http://0.0.0.0:5000");
            
            // Add database settings
            var dbSettings = new DbSettings();
            builder.Configuration.GetSection("DB").Bind(dbSettings);
            builder.Services.AddDbContext<ApiDbContext>(options =>
                options.UseNpgsql(dbSettings.ConnectionStrings.Api));
            

            builder.Logging.ClearProviders();
            
            builder.Logging.AddConsole();
            
            builder.Services.AddTransient<IPatientService, PatientService>();

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}