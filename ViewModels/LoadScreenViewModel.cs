using CommunityToolkit.Mvvm.Input;
using MauiTestApp.Data;
using MauiTestApp.Database;
using MauiTestApp.Models.Login;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific.AppCompat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTestApp.ViewModels
{
    public partial class LoadScreenViewModel
    {
        public LoadScreenViewModel()
        {
            try

            {
                var user = SQLiteDbManager.GetVerifiedUser();
                if (user==null)
                { 
                    Shell.Current.GoToAsync("Login");
                }
                else 
                {
                    Shell.Current.GoToAsync("WelcomeScreen");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [RelayCommand]
        public async Task GetLoginPage()
        {
            try
            {
                await Shell.Current.GoToAsync("Login");
            }
            catch { }

        }

    }
}

        //LoginResponse auth;
        //public LoadScreenViewModel()
        //{
        //    try
        //    {
        //        var objectOfDB = db.GetItemsAsync();
        //        if (objectOfDB != null)
        //        {
        //            Shell.Current.GoToAsync("WelcomeScreen");
        //        }
        //        else
        //        {
        //            Shell.Current.GoToAsync("Login");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error logging in: {ex.Message}");
        //    }
        //    finally
        //    {

        //    }
    
