using MauiTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTestApp.Helpers
{
    public class GlobalSetting
    {
        public const string DefaultEndpoint = "https://appselec-portal-api-qa.azurewebsites.net/";
        public static GlobalSetting Instance { get; } = new GlobalSetting();


    }
}
