using OnlineDanceStore.ViewModels;
namespace OnlineDanceStore.View;

public partial class LoginPage : ContentPage
{
   public LoginPage(LoginPageViewModels vm) 
    {
        this.BindingContext = vm;
        InitializeComponent();
        
    }
}