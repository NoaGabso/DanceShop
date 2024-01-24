using OnlineDanceStore.ViewModels;
namespace OnlineDanceStore.View.Categories;

public partial class DancingShoes : ContentPage
{
	public DancingShoes(CategoriesViewModel vm)
	{
        this.BindingContext = vm;
        InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CategoriesViewModel vm = (CategoriesViewModel)BindingContext;
        vm.GetAllDancingShoesCommand.Execute(null);
    }
}