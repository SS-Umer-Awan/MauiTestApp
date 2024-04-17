using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTestApp.Models.OTP
{
    public class VerifySmsAndMailOTPResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Result
        {
            public bool isCodeVerified { get; set; }
            public object errorMessage { get; set; }
            public string accessToken { get; set; }
            public string encryptedAccessToken { get; set; }
            public object passCode { get; set; }
            public object userEmail { get; set; }
            public int expireInSeconds { get; set; }
            public UserDetails userDetails { get; set; }
        }

      
            public Result result { get; set; }
            public object targetUrl { get; set; }
            public bool success { get; set; }
            public object error { get; set; }
            public bool unAuthorizedRequest { get; set; }
            public bool __abp { get; set; }
        

        public class UserDetails
        {
            public string userName { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public string emailAddress { get; set; }
            public bool isActive { get; set; }
            public string fullName { get; set; }
            public object lastLoginTime { get; set; }
            public DateTime creationTime { get; set; }
            public object roleNames { get; set; }
            public string phoneNumber { get; set; }
            public int departmentId { get; set; }
            public object department { get; set; }
            public string code { get; set; }
            public bool isTwoFactorEnabled { get; set; }
            public object smsCodeVerification { get; set; }
            public object smsCodeSendingTime { get; set; }
            public string emailCodeVerification { get; set; }
            public DateTime emailCodeSendingTime { get; set; }
            public object authenticationSecretKey { get; set; }
            public object forgotPassCode { get; set; }
            public object forgotPassCodeTime { get; set; }
            public List<object> roles { get; set; }
            public int id { get; set; }
        }


    }



}

