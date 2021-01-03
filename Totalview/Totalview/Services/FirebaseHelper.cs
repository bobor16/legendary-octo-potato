using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Totalview.Models;

namespace Totalview.Services
{
    public class FirebaseHelper
    {
        private readonly FirebaseClient client = new FirebaseClient("https://totalview-96914.firebaseio.com/");
        private readonly string FirebaseChild = "users";

        public async Task UpdateDatabase(string username, string state, string id, string password)
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
