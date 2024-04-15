using MauiTestApp.Data;

namespace MauiTestApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoadScreen), typeof(LoadScreen));
            Routing.RegisterRoute(nameof(Login), typeof(Login));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(OTP), typeof(OTP));
            Routing.RegisterRoute(nameof(WelcomeScreen), typeof(WelcomeScreen));
        }
    }
}
