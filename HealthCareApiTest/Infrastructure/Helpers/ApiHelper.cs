using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.ApiTest.Infrastructure.Helpers
{
    public static class ApiHelper
    {
        public static async Task SendPostRequest(string apiUrl, string json)
        {
            using HttpClient client = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);
            response.EnsureSuccessStatusCode();
        }
    }
}

