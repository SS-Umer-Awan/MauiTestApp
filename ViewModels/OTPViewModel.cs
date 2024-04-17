using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiTestApp.Services.Interface;
using Appselec.ViewModels;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Input;
using MauiTestApp.Models.OTP;
using MauiTestApp.Database;
using MauiTestApp.Models.Login;
using MauiTestApp.Models;

namespace MauiTestApp.ViewModels

{

    public partial class OTPViewModel : BaseViewModel
    {
        public string otp { get; set; }
        ChangeVerificationMethodRequest request;
        private ILogin _login;

        public OTPViewModel(ILogin authenticate)
        {
            _login = authenticate;
            request = SQLiteDbManager.GetChangeVerificationMethodRequest();
        }
        //ChangeVerificationMethodResponse ChangeVerMethodRes = await _login.ChangeVerificationMethod(req);
        [RelayCommand]
        public async Task ResendViaEmailOTP()
        {
            try
            {
                ChangeVerificationMethodResponse response = await _login.ChangeVerificationMethod(request);
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

        [RelayCommand]
        public async Task ResendViaSmsOTP()
        {
            try
            {
                request.authenticationType = 0;
                SQLiteDbManager.SaveChangeVerificationMethodRequest(request);
                ChangeVerificationMethodResponse response=  await _login.ChangeVerificationMethod(request);
            
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

        [RelayCommand]
        public async Task VerifyOTP()
        {
            try
            {
                LoginResponseResult loginResponseResult = SQLiteDbManager.GetLoginResponseResult();
                VerifySmsAndMailOTPRequest model=new VerifySmsAndMailOTPRequest() { otp=otp,authenticationType=request.authenticationType, usernameAndEmail=loginResponseResult.email};
                VerifySmsAndMailOTPResponse response = await _login.VerifySmsAndMailOTP(model);
                VerifiedUser User = new VerifiedUser()
                {
                    emailAddress = response.result.userDetails.emailAddress,
                    departmentId = response.result.userDetails.departmentId,
                    fullName = response.result.userDetails.fullName,
                    id = response.result.userDetails.id,
                    isActive = response.result.userDetails.isActive,
                    isTwoFactorEnabled = response.result.userDetails.isTwoFactorEnabled,
                    name = response.result.userDetails.name,
                    phoneNumber = response.result.userDetails.phoneNumber,
                    userName = response.result.userDetails.userName
                };
                SQLiteDbManager.SaveVerifiedUser(User);

                await Shell.Current.GoToAsync("WelcomeScreen");
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


