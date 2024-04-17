using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTestApp.Models.Login
{
    public class LoginResponseResult
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public int userId { get; set; }
        public string secretkey { get; set; }
        public string email { get; set; }
    }
}
