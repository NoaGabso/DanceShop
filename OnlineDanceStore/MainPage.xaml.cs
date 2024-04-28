using OnlineDanceStore.ViewModels;

namespace OnlineDanceStore;

public partial class MainPage : ContentPage
{


    public MainPage(MainPageViewModel vm)
    {
        this.BindingContext = vm;
        InitializeComponent();
    }

    private void MediaElement_StateChanged(object sender, CommunityToolkit.Maui.Core.Primitives.MediaStateChangedEventArgs e)
    {

    }
  
    //   private void loginclicked(object sender, EventArgs e)
    //{
    //       AppShell.Current.GoToAsync("Login");
    //   }


}