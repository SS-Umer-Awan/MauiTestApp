﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTestApp.Models.OTP
{
    public class VerifySmsAndMailOTPRequest
    {

        public string otp { get; set; }
        public string usernameAndEmail { get; set; }
        public int authenticationType { get; set; }
    }

}

