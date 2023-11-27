using OnlineDanceStore.ViewModels;
namespace OnlineDanceStore.View;

public partial class HomePage : ContentPage
{
    public HomePage(HomePageViewModel vm)
    {
        this.BindingContext = vm;
        InitializeComponent();

    }
}