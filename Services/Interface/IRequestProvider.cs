using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTestApp.Services.Interface
{
    public interface IRequestProvider
    {
        Task<TResult> PostAsync<TResult>(string url, StringContent stringContent, string token = "", string header = "");
    }
}
