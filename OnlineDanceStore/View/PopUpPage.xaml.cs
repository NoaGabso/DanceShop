using CommunityToolkit.Maui.Views;

namespace OnlineDanceStore.View;

public partial class PopUpPage:Popup
{
    public string ImagePath { get; set; }

    public PopUpPage(string image)
    {
       
        ImagePath = image;

        InitializeComponent();
        
        BindingContext = this;
    }
    public async Task ShowAsync()
    {
        Console.WriteLine($"Showing image: {ImagePath}");
        // כאן תכלול את הלוגיקה להצגת החלון הקופץ בפועל
        await Task.Delay(100); // סימולציה של פעולה אסינכרונית
    }
}