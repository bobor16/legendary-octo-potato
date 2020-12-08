using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Totalview.Models
{
    public class UserModel
    {
        public UserModel()
        {

        }

        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("ID")]
        public int ID { get; set; }
    }
}
