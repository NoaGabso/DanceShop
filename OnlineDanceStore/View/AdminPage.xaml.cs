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
        await OnButtonClickedAsync(vm);

    }

    private async Task OnButtonClickedAsync(AdminPageViewModel vm)
    {
        string imagePath = await vm.ShowImageAsync();
        if (!string.IsNullOrEmpty(imagePath))
        {
            PopUpPage popup = new PopUpPage(imagePath);
            await popup.ShowAsync();
        }
        else
        {
            // תצוגת הודעת שגיאה למשתמש
            await DisplayAlert("Error", "Image source is not available", "OK");
        }
    }

}