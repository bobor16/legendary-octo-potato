using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Totalview.Models;
using Totalview.Services.Interfaces;

namespace Totalview.Services
{
    class ServerConnection
    {
        public static async Task RefreshDataAsync()
        {
            var uri = new Uri("https://totalview-96914.web.app/user.json");
            HttpClient myClient = new HttpClient();
            var response = await myClient.GetAsync(uri);
            Console.WriteLine(response.StatusCode + " Before response.IsSuccessStatusCode");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                //var Items = JsonConvert.DeserializeObject<List<UserModel>>(content);
                Console.WriteLine(content);
            }
        }
    }
}
