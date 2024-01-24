using OnlineDanceStore.ViewModels;
namespace OnlineDanceStore.View.Categories;

public partial class Accessories : ContentPage
{
	public Accessories(CategoriesViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CategoriesViewModel vm= (CategoriesViewModel)BindingContext;    
         vm.GetAllAccessoriesCommand.Execute(null);
    }
}