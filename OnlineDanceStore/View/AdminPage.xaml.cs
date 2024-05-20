using OnlineDanceStore.ViewModels;
using CommunityToolkit.Maui.Views;

namespace OnlineDanceStore.View;

public partial class AdminPage : ContentPage
{
    public AdminPage(AdminPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        InitializeAsync(vm);
    }

    private async Task InitializeAsync(AdminPageViewModel vm)
    {
        await vm.GetSetUpData();
    }
    //protected override async void OnAppearing()
    //{
    //    base.OnAppearing();
    //    AdminPageViewModel vm = (AdminPageViewModel)BindingContext;
    //    vm.GetSetUpData();
    //}
}