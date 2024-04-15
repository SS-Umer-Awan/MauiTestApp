using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTestApp.Models.OTP
{
    public class VerifySmsAndMailOTPResponse
    {
        public bool isCodeVerified { get; set; }
        public string errorMessage { get; set; }
        public string accessToken { get; set; }
        public string encryptedAccessToken { get; set; }
        public string passCode { get; set; }
        public string userEmail { get; set; }
        public int expireInSeconds { get; set; }
        public Userdetails userDetails { get; set; }
    }

    public class Userdetails
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string emailAddress { get; set; }
        public bool isActive { get; set; }
        public string fullName { get; set; }
        public DateTime lastLoginTime { get; set; }
        public DateTime creationTime { get; set; }
        public string[] roleNames { get; set; }
        public string phoneNumber { get; set; }
        public int departmentId { get; set; }
        public Department department { get; set; }
        public string code { get; set; }
        public bool isTwoFactorEnabled { get; set; }
        public string smsCodeVerification { get; set; }
        public DateTime smsCodeSendingTime { get; set; }
        public string emailCodeVerification { get; set; }
        public DateTime emailCodeSendingTime { get; set; }
        public string authenticationSecretKey { get; set; }
        public string forgotPassCode { get; set; }
        public DateTime forgotPassCodeTime { get; set; }
        public Role[] roles { get; set; }
    }

    public class Department
    {
        public int id { get; set; }
        public DateTime creationTime { get; set; }
        public int creatorUserId { get; set; }
        public DateTime lastModificationTime { get; set; }
        public int lastModifierUserId { get; set; }
        public bool isDeleted { get; set; }
        public int deleterUserId { get; set; }
        public DateTime deletionTime { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
    }

    public class Role
    {
        public int id { get; set; }
        public DateTime creationTime { get; set; }
        public int creatorUserId { get; set; }
        public int tenantId { get; set; }
        public int userId { get; set; }
        public int roleId { get; set; }
    }

}

