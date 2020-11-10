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
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
