using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTestApp.Models.OTP
{
    public class OTPAccessTokenCreateResponse
    {
        public string accessToken { get; set; }
        public string en { get; set; }

        public class Rootobject
        {
            public Result result { get; set; }
            public object targetUrl { get; set; }
            public bool success { get; set; }
            public object error { get; set; }
            public bool unAuthorizedRequest { get; set; }
            public bool __abp { get; set; }
        }

        public class Result
        {
            public string accessToken { get; set; }
            public string encryptedAccessToken { get; set; }
            public int expireInSeconds { get; set; }
            public int userId { get; set; }
        }

    }
}
