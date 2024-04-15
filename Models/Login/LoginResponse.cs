using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTestApp.Models.Login
{
    public class LoginResponse
    {

        public Result result { get; set; }
        public string targetUrl { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
        public bool unAuthorizedRequest { get; set; }
        public bool __abp { get; set; }
    }

    public class Result
    {
        public int statusCode { get; set; }
        public string message { get; set; }

        public int userId { get; set; }
        public string email { get; set; }
    }
    
}

