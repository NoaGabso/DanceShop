
using OnlineDanceStore.Models;


namespace OnlineDanceStore;

public partial class App : Application
{
	public User UserinApp { get; set; }
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		
	}
}
