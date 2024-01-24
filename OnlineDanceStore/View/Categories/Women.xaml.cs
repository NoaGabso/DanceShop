using OnlineDanceStore.ViewModels;
namespace OnlineDanceStore.View.Categories;

public partial class Women : ContentPage
{
	public Women(CategoriesViewModel vm)
	{
        this.BindingContext = vm;
        InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CategoriesViewModel vm = (CategoriesViewModel)BindingContext;
        vm.GetItemsForWomenCommand.Execute(null);
    }
}