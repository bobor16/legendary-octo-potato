using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Totalview.Models;
using Totalview.ViewModels;

namespace Totalview.Services
{
    public class DataHandler
    {
        private readonly string serverName = "https://totalview-96914.web.app/users.json";
        private string content;

        private LoginPageViewModel viewModel;
        public DataHandler(LoginPageViewModel input)
        {
            viewModel = input;
        }

        public async Task getDataAsync()
        {
            var uri = new Uri(serverName);
            HttpClient myClient = new HttpClient();
            var response = await myClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
                Dictionary<String, UserModel> desenteralizedObject = JsonConvert.DeserializeObject<Dictionary<String, UserModel>>(content);

                if (desenteralizedObject != null)
                {
                    foreach (var item in desenteralizedObject.Values)
                    {
                        Root list = viewModel.root;
                        list.UserList.Add(new UserModel
                        {
                            id = item.id,
                            password = item.password,
                            state = item.state,
                            username = item.username
                        });
                    };
                }
            }
        }
    }
}
