using Newtonsoft.Json;
using System.Collections.Generic;

namespace Totalview.Models
{
    public class UserModel
    {
        //[JsonProperty(PropertyName = "ID")]
        //public string ID { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string password { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string username { get; set; }
    }
    public class Root
    {
        public Root()
        {
            UserList = new List<UserModel>();
        }

        [JsonProperty(PropertyName = "user")]
        public List<UserModel> UserList { get; set; }
        public int count { get; set; }
    }
}

