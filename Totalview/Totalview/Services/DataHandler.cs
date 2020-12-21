using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Totalview.Models;
using Totalview.ViewModels;

namespace Totalview.Services
{
    public class DataHandler
    {
        private readonly string serverName = "https://totalview-96914.web.app/user.json";
        private string content;
        private LoginPageViewModel viewModel;

        public DataHandler(LoginPageViewModel input)
        {
            //getDataAsync();
            viewModel = input;
        }

        public async Task getDataAsync()
        {
            var uri = new Uri(serverName);
            HttpClient myClient = new HttpClient();
            var response = await myClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Sucessfully connected to the most awesome website of all time!... :D");

                content = await response.Content.ReadAsStringAsync();
                var desenteralizedObject = JsonConvert.DeserializeObject<List<UserModel>>(content);


                if (desenteralizedObject != null)
                {
                    for (int i = 0; i < desenteralizedObject.Count; i++)
                    {
                        Debug.WriteLine("Username: " + desenteralizedObject[i].username + " Password: " + desenteralizedObject[i].password);
                    }
                    foreach (var item in desenteralizedObject)
                    {
                        Root list = viewModel.root;
                        list.UserList.Add(new UserModel
                        {
                            password = item.password,
                            username = item.username
                        });
                    }
                    Debug.WriteLine("break");
                }
            }
        }
    }
}
