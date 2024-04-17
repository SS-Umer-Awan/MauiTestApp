using MauiTestApp.Data;
using MauiTestApp.Models;
using MauiTestApp.Services.Implementation;
using MauiTestApp.Services.Interface;
using MauiTestApp.ViewModels;

namespace MauiTestApp;

public partial class Login : ContentPage
{
    LoginViewModel viewModel;
    public Login(LoginViewModel vm)
    {
        InitializeComponent();
        this.viewModel = vm;
        BindingContext = vm;
    }


}