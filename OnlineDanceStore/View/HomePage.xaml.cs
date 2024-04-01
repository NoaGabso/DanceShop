using OnlineDanceStore.ViewModels;
namespace OnlineDanceStore.View;

public partial class HomePage : ContentPage
{
    public HomePage(HomePageViewModel vm)
    {
        this.BindingContext = vm;
        InitializeComponent();
        

    }

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    foreach (var x in Shell.Current.OrderItems)
    //    {
    //        if (x.CurrentItem.CurrentItem.Route == nameof(MainPage)) { x.FlyoutItemIsVisible = false; }
            
    //        else x.FlyoutItemIsVisible = true;
    //    }
    //}
}