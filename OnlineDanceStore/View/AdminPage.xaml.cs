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
     // await OnButtonClickedAsync(vm);

    }

   

}