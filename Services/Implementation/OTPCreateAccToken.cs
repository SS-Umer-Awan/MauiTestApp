using MauiTestApp.Helpers;
using MauiTestApp.Models;
using MauiTestApp.Models.Login;
using MauiTestApp.Models.OTP;
using MauiTestApp.Services.Interface;
using Newtonsoft.Json;


namespace MauiTestApp.Services.Implementation
{
    public class OTPCreateAccToken : IOTPCreateAccToken
    {
        //private readonly IRequestProvider _requestProvider;
        //public OTPCreateAccToken(IRequestProvider requestProvider)
        //{
        //    _requestProvider = requestProvider;
        //}

        //// Login User Implementation
        //public async Task<OTPAccessTokenCreateResponse> OtpResponse(OTPAccessTokenCreateRequest authenticationInput)
        //{
        //    OTPAccessTokenCreateResponse response = null;
            

        //    var url = GlobalSetting.DefaultEndpoint + $"api/TokenAuth/CreateAccessTokenWithOtp/?name={authenticationInput.name}&id={authenticationInput.id}";
        //    //var url = "https://funtealleaf22.conveyor.cloud/api/TokenAuth/Authenticate";
        //    try
        //    {
        //        response = await _requestProvider.PostAsync<OTPAccessTokenCreateResponse>(url, new StringContent(JsonConvert.SerializeObject(authenticationInput)));
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Console.WriteLine($"Error logging in: {ex.Message}");
        //    }
        //    return response;
        //}

        //Task<OTPAccessTokenCreateResponse> IOTPCreateAccToken.OTPCreateAccToken(OTPAccessTokenCreateRequest authenticationInput)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
