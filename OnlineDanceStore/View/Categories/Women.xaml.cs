using CommunityToolkit.Maui.Views;
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