using CommunityToolkit.Mvvm.Input;
using MauiTestApp.Data;
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
        
        LoginResponse auth;
        
        [RelayCommand]
        public async Task Logout()
        {
            try
            {
                var objectOfDB=db.DeleteAllItemsAsync();
                if (objectOfDB != null)
                {
                    await Shell.Current.GoToAsync("WelcomeScreen");
                }
                else
                {
                    await Shell.Current.GoToAsync("Login");
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
