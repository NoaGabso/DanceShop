using OnlineDanceStore.ViewModels;

namespace OnlineDanceStore.View;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewModel vm)
	{
		this.BindingContext = vm;
        InitializeComponent();
		
	}
}