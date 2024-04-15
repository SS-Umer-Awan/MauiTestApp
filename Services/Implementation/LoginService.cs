using MauiTestApp.Helpers;
using MauiTestApp.Models;
using MauiTestApp.Models.Login;
using MauiTestApp.Models.OTP;
using MauiTestApp.Services.Interface;
using Newtonsoft.Json;


namespace MauiTestApp.Services.Implementation
{
    public class LoginService : ILogin
    {
        private readonly IRequestProvider _requestProvider;
        public LoginService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        // Login User Implementation
        public async Task<LoginResponse> LoginUser(LoginRequest authenticationInput)
        {
            LoginResponse response = null;
            

            var url = GlobalSetting.DefaultEndpoint + "api/TokenAuth/Authenticate";

            try
            {
                response = await _requestProvider.PostAsync<LoginResponse>(url, new StringContent(JsonConvert.SerializeObject(authenticationInput)));
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error logging in: {ex.Message}");
            }
            return response;
        }

        public async Task<OTPAccessTokenCreateResponse> OTPCreateAccToken(OTPAccessTokenCreateRequest authenticationInput)
        {
            OTPAccessTokenCreateResponse response = null;


            var url = GlobalSetting.DefaultEndpoint + $"api/TokenAuth/CreateAccessTokenWithOtp/?name={authenticationInput.name}&id={authenticationInput.id}";
            try
            {
                response = await _requestProvider.PostAsync<OTPAccessTokenCreateResponse>(url, new StringContent(JsonConvert.SerializeObject(authenticationInput)));
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error logging in: {ex.Message}");
            }
            return response;
        }

        public async Task<VerifySmsAndMailOTPResponse> VerifySmsAndMailOTP(VerifySmsAndMailOTPRequest authenticationInput)
        {
            VerifySmsAndMailOTPResponse response = null;


            var url = GlobalSetting.DefaultEndpoint + "api/TokenAuth/VerifySmsAndMailOtp";
            try
            {
                response = await _requestProvider.PostAsync<VerifySmsAndMailOTPResponse>(url, new StringContent(JsonConvert.SerializeObject(authenticationInput)));
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error logging in: {ex.Message}");
            }
            return response;
        }
    }
}
