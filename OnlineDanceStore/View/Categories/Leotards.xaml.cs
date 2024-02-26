using OnlineDanceStore.ViewModels;
namespace OnlineDanceStore.View.Categories;

public partial class Leotards : ContentPage
{
	public Leotards(CategoriesViewModel vm)
	{
        this.BindingContext = vm;
        InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CategoriesViewModel vm = (CategoriesViewModel)BindingContext;
        vm.GetAllLeotardsCommand.Execute(null);
       
    }
}