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
        ButtonClickedHandler(vm);
    }

    private async Task InitializeAsync(AdminPageViewModel vm)
    {
        await vm.GetSetUpData();

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
            Console.WriteLine("Image source is not available");
            // כאן ניתן לכלול טיפול במקרה שהתמונה לא זמינה
        }
    }

    // דוגמה לקריאה למתודה האסינכרונית (למשל באירוע לחיצה על כפתור)
    public async Task ButtonClickedHandler(AdminPageViewModel vm)
    {
        await OnButtonClickedAsync(vm);
    }

}