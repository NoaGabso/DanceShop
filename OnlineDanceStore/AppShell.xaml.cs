using OnlineDanceStore.View;
using OnlineDanceStore.View.Categories;
namespace OnlineDanceStore;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("Register", typeof(RegisterPage));
        Routing.RegisterRoute("Login", typeof(LoginPage));
       
        
       


    }
}
