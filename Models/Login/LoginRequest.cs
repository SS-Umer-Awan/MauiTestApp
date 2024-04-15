using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiTestApp.Models
{
    public class LoginRequest
    {
        //[PrimaryKey,AutoIncrement]
        //public int ID { get;set; }
        public string userNameOrEmailAddress { get; set; }
        public string password { get; set; }
        public bool rememberClient { get; set; }
    }
}
