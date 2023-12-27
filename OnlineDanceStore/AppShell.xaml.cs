using OnlineDanceStore.View;

namespace OnlineDanceStore;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("Register", typeof(RegisterPage));
        Routing.RegisterRoute("Login", typeof(LoginPage));
        Routing.RegisterRoute("HomePage", typeof(HomePage));
        Routing.RegisterRoute("ShoppingCart", typeof(ShoppingCart));
        Routing.RegisterRoute("UserInfo", typeof(UserInfo));


    }
}
