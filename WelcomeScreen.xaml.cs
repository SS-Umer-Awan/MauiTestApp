using MauiTestApp.ViewModels;

namespace MauiTestApp;

public partial class WelcomeScreen : ContentPage
{
    WelcomeVM vm;
    
    public WelcomeScreen()
    {
        InitializeComponent();
        vm = new WelcomeVM();
        BindingContext = vm;
    }
    
}