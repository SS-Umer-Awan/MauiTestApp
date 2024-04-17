using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTestApp.Models
{
    public class VerifiedUser
    {
        public string userName { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public bool isActive { get; set; }
        public string fullName { get; set; }
        public string phoneNumber { get; set; }
        public int departmentId { get; set; }
        public bool isTwoFactorEnabled { get; set; }
        public int id { get; set; }
    }
}
