using OnlineDanceStore.ViewModels;
using CommunityToolkit.Maui.Views;

namespace OnlineDanceStore.View;

public partial class AdminPage : ContentPage
{
    public AdminPage(AdminPageViewModel vm)
	{
        this.BindingContext = vm;

        InitializeComponent();
	}
      protected override async void OnAppearing()
    {
        base.OnAppearing();
       AdminPageViewModel vm = (AdminPageViewModel)BindingContext;
        await vm.GetSetUpData();
    }
}