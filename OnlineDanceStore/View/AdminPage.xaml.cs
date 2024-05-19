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

    private async Task InitializeAsync(AdminPageViewModel vm) // Changed from void to Task
    {
        await vm.GetSetUpData();
    }
}