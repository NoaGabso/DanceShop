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
}