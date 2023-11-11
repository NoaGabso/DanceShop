using OnlineDanceStore.ViewModels;

namespace OnlineDanceStore;

public partial class MainPage : ContentPage
{


    public MainPage(MainPageViewModel vm)
    {
        this.BindingContext = vm;
        InitializeComponent();
    }

 //   private void loginclicked(object sender, EventArgs e)
	//{
 //       AppShell.Current.GoToAsync("Login");
 //   }


}