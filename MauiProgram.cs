using MauiTestApp.Services.Implementation;
using MauiTestApp.Services.Interface;
using MauiTestApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiTestApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddTransient<LoadScreenViewModel>();
            builder.Services.AddTransient<LoadScreen>();
            builder.Services.AddTransient<WelcomeScreen>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<ILogin, LoginService>();
            builder.Services.AddTransient<IRequestProvider, RequestProvider>();
            



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
