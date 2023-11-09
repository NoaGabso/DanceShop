namespace OnlineDanceStore;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void loginclicked(object sender, EventArgs e)
	{
        AppShell.Current.GoToAsync("Login");
    }


}