using MauiTestApp.Data;

namespace MauiTestApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LoginDatabase db = new LoginDatabase();
            
            MainPage = new AppShell();
        }
    }
}
