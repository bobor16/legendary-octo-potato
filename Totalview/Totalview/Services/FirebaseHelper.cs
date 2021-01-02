using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Totalview.Models;
using Totalview.ViewModels;

namespace Totalview.Services
{
    public class FirebaseHelper
    {
        private FirebaseClient client = new FirebaseClient("https://totalview-96914.firebaseio.com/");
        private readonly string FirebaseChild = "users";



        public async Task AddPerson(string personId, string name, string password, string state)
        {
            await client
              .Child(FirebaseChild)
              .PostAsync(new UserModel()
              {
                  id = personId,
                  username = name,
                  password = password,
                  state = state
              });
        }

        public async Task UpdatePerson(string username, string state, string id, string password)
        {
            try
            {
                var toUpdatePerson = (await client
                  .Child(FirebaseChild)
                  .OnceAsync<UserModel>())
                  .Where(a => a.Object.username == username)
                  .FirstOrDefault();

                await client
                  .Child(FirebaseChild)
                  .Child(toUpdatePerson.Key)
                  .PatchAsync(new UserModel()
                  {
                      id = id,
                      password = password,
                      state = state,
                      username = username
                  });
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error: {e}");
            }
        }
    }
}
