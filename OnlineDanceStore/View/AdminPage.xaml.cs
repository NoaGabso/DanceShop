using OnlineDanceStore.ViewModels;
using CommunityToolkit.Maui.Views;

namespace OnlineDanceStore.View;

public partial class AdminPage : ContentPage
{
    public AdminPage(AdminPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        
        
    }

 


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        AdminPageViewModel vm = (AdminPageViewModel)BindingContext;
        if(vm.PageLoaded)
            await vm.GetSetUpData();
    }
}