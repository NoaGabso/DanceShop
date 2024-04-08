using OnlineDanceStore.ViewModels;

namespace OnlineDanceStore.View;

public partial class UserInfoPage : ContentPage
{
	public UserInfoPage(UserInfoViewModel vm)
	{
        this.BindingContext = vm;
        InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        UserInfoViewModel vm = (UserInfoViewModel)BindingContext;
        vm.GetOrdersByUserCommand.Execute(null);
    }
}