using CommunityToolkit.Mvvm.Input;
using MauiTestApp.Data;
using MauiTestApp.Database;
using MauiTestApp.Models;
using MauiTestApp.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTestApp.ViewModels
{
    public partial class WelcomeVM
    {
        VerifiedUser SessionUser;
        public WelcomeVM() 
        {
            SessionUser = SQLiteDbManager.GetVerifiedUser();
            if (SessionUser==null)
            {
                Shell.Current.GoToAsync("LoadScreen");

            }
        }

        
        [RelayCommand]
        public async Task Logout()
        {
            try
            {
                SQLiteDbManager.RemoveEverythingFromDB();
                await Shell.Current.GoToAsync("LoadScreen");
            }
            catch { }

        }
    }
}
