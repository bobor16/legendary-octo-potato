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
    class DataHandler
    {

        public DataHandler()
        {
            GetDataAsync();
        }

        public async Task GetDataAsync()
        {
            var uri = new Uri("https://totalview-96914.web.app/user.json");
            HttpClient myClient = new HttpClient();
            var response = await myClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<UserModel>>(content);

                userID = Items[0].ID;
                username = Items[0].Username;
                password = Items[0].Password;

                //Console.WriteLine(userID + " " + username + " Aaaaannd " + password);
                Console.WriteLine("Sucessfully connected to the most awesome website of all time!...");
            }
        }

        private int userID;
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

    }
}
