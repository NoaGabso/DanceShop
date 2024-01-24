using OnlineDanceStore.ViewModels;
namespace OnlineDanceStore.View.Categories;

public partial class Men : ContentPage
{
	public Men(CategoriesViewModel vm)
	{
        this.BindingContext = vm;
        InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CategoriesViewModel vm = (CategoriesViewModel)BindingContext;
        vm.GetItemsForMenCommand.Execute(null);
    }
}