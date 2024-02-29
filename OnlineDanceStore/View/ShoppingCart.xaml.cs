using OnlineDanceStore.ViewModels;

namespace OnlineDanceStore.View;

public partial class ShoppingCart : ContentPage
{
	public ShoppingCart(ShoppingCartViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}