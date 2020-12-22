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
        public List<UserModel> userList = new List<UserModel>();
        public DataHandler()
        {
            
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

                Console.WriteLine("Connected to server and retrieved data...");
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
