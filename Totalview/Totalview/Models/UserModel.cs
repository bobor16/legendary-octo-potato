using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Totalview.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }
    }
}
