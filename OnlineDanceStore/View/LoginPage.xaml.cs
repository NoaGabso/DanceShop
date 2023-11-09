using OnlineDanceStore.ViewModels;
namespace OnlineDanceStore.View;

public partial class LoginPage : ContentPage
{
   public LoginPage(LoginPageViewModel vm) 
    {
        this.BindingContext = vm;
        InitializeComponent();
    }
}