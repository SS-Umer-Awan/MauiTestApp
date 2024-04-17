namespace MauiTestApp;

using CommunityToolkit.Mvvm.Input;
using MauiTestApp.Data;
using MauiTestApp.Models.Login;
using MauiTestApp.ViewModels;
public partial class LoadScreen : ContentPage
{
    public LoadScreen()
    {
        InitializeComponent();
        BindingContext = new LoadScreenViewModel();

    }


}