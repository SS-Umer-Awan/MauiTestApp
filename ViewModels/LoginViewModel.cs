using MauiTestApp.Data;
using MauiTestApp.Models;
using MauiTestApp.Services.Interface;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Appselec.ViewModels;
using MauiTestApp.Services.Implementation;
using MauiTestApp.Models.Login;
using SQLite;
using MauiTestApp.Database;
using MauiTestApp.Models.OTP;

namespace MauiTestApp.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string userName="";
        [ObservableProperty]
        private string password = "";
        [ObservableProperty]
        private bool cb;


        private ILogin _login;

        LoginRequest authenticationInputModel;

        //LoginDatabase db=new LoginDatabase();

        public LoginViewModel(ILogin authenticate)
        {
            _login = authenticate;
        }


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
                        if (user.result.statusCode == 200)
                        
                        {
                            LoginResponseResult res = new LoginResponseResult() { email=user.result.email,userId=user.result.userId,message=user.result.message,secretkey=user.result.message,statusCode=user.result.statusCode};
                            SQLiteDbManager.SaveLoginResponseResult(res);
                            OTPAccessTokenCreateRequest OTPCreateReq = new OTPAccessTokenCreateRequest() { id = user.result.userId, name = user.result.email };
                            OTPAccessTokenCreateResponse OTPCreateRes = await _login.OTPCreateAccToken(OTPCreateReq);
                            if (OTPCreateRes.success)
                            {
                                if (OTPCreateRes.error == null && OTPCreateRes.unAuthorizedRequest == false)
                                {
                                    //SQLiteDbManager.SaveOTPAccessTokenCreateResponse(OTPCreateRes);
                                    ChangeVerificationMethodRequest req = new ChangeVerificationMethodRequest() { userId = user.result.userId, authenticationType = 1, secretKey = user.result.secretkey };
                                    SQLiteDbManager.SaveChangeVerificationMethodRequest(req);
                                    var ChangeVerMethodRes = await _login.ChangeVerificationMethod(req);
                                    await Shell.Current.GoToAsync("OTP");
                                }
                            }
                        }
                        else
                        {
                        }
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

