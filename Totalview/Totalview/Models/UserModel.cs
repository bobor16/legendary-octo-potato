using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Totalview.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class UserModel
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string password { get; set; }
        [JsonProperty(PropertyName = "state")]
        public string state { get; set; }
        [JsonProperty(PropertyName = "username")]
        public string username { get; set; }
    }

    public class Root
    {
        public Root()
        {
            UserList = new List<UserModel>();
            keys = new Dictionary<string, UserModel>();
        }

        [JsonProperty(PropertyName = "users")]
        public List<UserModel> UserList { get; set; }
        public Dictionary<String, UserModel> keys { get; set; }
    }
}

