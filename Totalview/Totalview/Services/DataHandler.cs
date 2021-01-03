using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Totalview.Models;
using Totalview.ViewModels;

namespace Totalview.Services
{
    /// <summary>
    /// DataHandler class handles all the communication between the client and server.
    /// </summary>
    public class DataHandler
    {
        private readonly string serverName = "https://totalview-96914.web.app/users.json";
        private string content;

        private LoginPageViewModel viewModel;
        public DataHandler(LoginPageViewModel input)
        {
            viewModel = input;
        }
        /*
         Creates a http client that returns a response code between 200 - 299,
        The response json file provided by the server is the deserialized into a 
        dictionary and placed into the usermodel.
         */
        public async Task getDataAsync()
        {
            var uri = new Uri(serverName);
            HttpClient myClient = new HttpClient();
            var response = await myClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
                /*
                 The user information is located in the usermodel node which is located in the root node.
                Each user created in the firebase in placed in a node with a usermodel node.
                 */
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
