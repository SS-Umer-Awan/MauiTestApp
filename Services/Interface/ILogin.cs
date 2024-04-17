using MauiTestApp.Models;
using MauiTestApp.Models.Login;
using MauiTestApp.Models.OTP;


namespace MauiTestApp.Services.Interface
{
    public interface ILogin
    {
        Task<LoginResponse> LoginUser(LoginRequest authenticationInput);
        Task<OTPAccessTokenCreateResponse> OTPCreateAccToken(OTPAccessTokenCreateRequest authenticationInput);
        Task<ChangeVerificationMethodResponse> ChangeVerificationMethod(ChangeVerificationMethodRequest authenticationInput);
        Task<VerifySmsAndMailOTPResponse> VerifySmsAndMailOTP(VerifySmsAndMailOTPRequest authenticationInput);
    }
}
