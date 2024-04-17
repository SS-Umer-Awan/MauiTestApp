using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTestApp.Models.OTP
{
    public class ChangeVerificationMethodRequest
    { 
        public int userId { get; set; }
        public int authenticationType { get; set; }
        public string secretKey { get; set; }
    }
}
