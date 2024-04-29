using CommunityToolkit.Maui.Views;
using OnlineDanceStore.ViewModels;

namespace OnlineDanceStore.View;

public partial class ShoppingCart : ContentPage
{
	public ShoppingCart(ShoppingCartViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		var vm=BindingContext as ShoppingCartViewModel;
		if (vm != null)
		{
			await vm.Refresh();
			

		}
    }
    private void OnButtonClicked(object sender, EventArgs e)
    {
        if (sender is ImageButton button && button.CommandParameter is string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                this.ShowPopup(new PopUpPage(imagePath));
            }
            else
            {
                Console.WriteLine("Image source is not available");
                // Handle this case accordingly
            }
        }
    }
}