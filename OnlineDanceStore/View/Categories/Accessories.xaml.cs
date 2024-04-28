using CommunityToolkit.Maui.Views;
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
    protected void OnButtonClicked(object sender, EventArgs e)
    {
        // Cast the sender back to an ImageButton
        ImageButton button = (ImageButton)sender;

        // Get the Source of the ImageButton
        ImageSource imageSource = button.Source;

        if (imageSource != null)
        {
            // Convert ImageSource to a string representation of the image
            string imageIdentifier = imageSource.ToString();

            // Show the popup with the image identifier
            this.ShowPopup(new PopUpPage(imageIdentifier));
        }
        else
        {
            Console.WriteLine("Image source is not available");
            // Handle this case accordingly
        }
    }
}