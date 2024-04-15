using CommunityToolkit.Mvvm.Input;
using MauiTestApp.Data;
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
        LoginDatabase db = new LoginDatabase();
        LoginResponse auth;
        public LoadScreenViewModel()
        {
            try
            { 
                var objectOfDB = db.GetItemAsync();
                if (objectOfDB != null)
                {

                    Shell.Current.GoToAsync("WelcomeScreen");
                }
                else
                {
                    Shell.Current.GoToAsync("Login");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging in: {ex.Message}");
            }
            finally
            {

            }
        }
    }    
}