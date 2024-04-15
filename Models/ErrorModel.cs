using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTestApp.Models
{
    public class ErrorModel
    {
        public object result { get; set; }
        public object targetUrl { get; set; }
        public bool success { get; set; }
        public Error error { get; set; }
        public bool unAuthorizedRequest { get; set; }
        public bool __abp { get; set; }

        public class Error
        {
            public int code { get; set; }
            public string message { get; set; }
            public string details { get; set; }
            public object validationErrors { get; set; }
        }

    }

}
