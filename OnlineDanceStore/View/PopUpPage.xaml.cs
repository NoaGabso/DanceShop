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
}