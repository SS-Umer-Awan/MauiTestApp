using MauiTestApp.Models;
using MauiTestApp.Services.Implementation;
using MauiTestApp.Services.Interface;
using MauiTestApp.ViewModels;

namespace MauiTestApp;

public partial class Login : ContentPage
{
    LoginService login;
    public Login()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel(login);
    }


}