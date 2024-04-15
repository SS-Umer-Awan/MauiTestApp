using Appselec.ViewModels;
using CommunityToolkit.Mvvm.Input;
using MauiTestApp.Models.OTP;
using MauiTestApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTestApp.ViewModels.LoginViewModels
{
    public partial class VerifySmsAndMailOTPViewModel : BaseViewModel
    {
        public string UsernameAndEmail { get; set; }
        public string Otp { get; set; }
        public int AuthenticationType { get; set; }
        public Command VerifyCommand { get; set; }

        private readonly ILogin _authenticate;

        public VerifySmsAndMailOTPViewModel(ILogin authenticate)
        {
            _authenticate = authenticate;
            VerifyCommand = new Command(async _ => await VerifyOtpAsync());
            
        }

        public VerifySmsAndMailOTPViewModel()
        {
        }

        [RelayCommand]
        public async Task VerifyOtpAsync()
        {
            try
            {
                IsBusy = true;
                if (string.IsNullOrEmpty(Otp))
                {
                    await Shell.Current.DisplayAlert("Error", "Please Enter OTP", "OK");
                    return;
                }

                // Retrieve username from secure storage
                var username = await SecureStorage.GetAsync("username");

                //Console.WriteLine(username);
                var verifyOtpInputModel = new VerifySmsAndMailOTPRequest
                {
                    otp = Otp,
                    usernameAndEmail = username,
                    authenticationType = AuthenticationType
                };

                var response = await _authenticate.VerifySmsAndMailOTP(verifyOtpInputModel);

                //if (response.ResultData.isCodeVerified)
                //{
                //    //await Shell.Current.GoToAsync("//DashBoardShell");
                //    App.Current.MainPage = new DashBoardShell();
                //}
                //else
                //{
                //    await Shell.Current.DisplayAlert("Error", (string)response.Error, "OK");
                //}
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
