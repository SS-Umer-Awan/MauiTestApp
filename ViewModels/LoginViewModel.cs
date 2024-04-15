using MauiTestApp.Data;
using MauiTestApp.Models;
using MauiTestApp.Services.Interface;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Appselec.ViewModels;
using MauiTestApp.Services.Implementation;

namespace MauiTestApp.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string userName="";
        [ObservableProperty]
        private string password = "";
        [ObservableProperty]
        private bool cb = false;

        private ILogin _login;

        LoginDatabase db = new LoginDatabase();

        LoginRequest authenticationInputModel;

        public LoginViewModel(ILogin authenticate)
        {
            _login = authenticate;
        }

        //public LoginViewModel()
        //{
        //    try
        //    {
        //        IsBusy = true;
        //        authenticationInputModel = new LoginRequest()
        //        {
        //            userNameOrEmailAddress = userName,
        //            password = password,
        //            rememberClient = cb,
        //        };

        //        var Current = Connectivity.NetworkAccess;
        //        if (Current == NetworkAccess.Internet)
        //        {
        //            var user = _login.LoginUser(authenticationInputModel);

        //            if (user.Result.success)
        //            {

        //                db.SaveItemAsync(user.Result);
        //            }
        //            else if(user.Result.result.statusCode == 401)
        //            {
        //                    //SAHIIII WALA PASSWORDD LGA NA  USTAAD
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error logging in: {ex.Message}");
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}


        [RelayCommand]
        public async Task Login()
        {
            try
            {
                IsBusy = true;
                authenticationInputModel = new LoginRequest()
                {
                    userNameOrEmailAddress = userName,
                    password = password,
                    rememberClient = cb,
                };

                var Current = Connectivity.NetworkAccess;
                if (Current == NetworkAccess.Internet)
                {
                    var user = await _login.LoginUser(authenticationInputModel);

                    if (user.success)
                    {
                        
                        db.SaveItemAsync(user);
                        // Store username securely (e.g., using Secure Storage)
                    }
                    else if(user.result.statusCode == 401)
                    {
                            //SAHIIII WALA PASSWORDD LGA NA  USTAAD
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging in: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

