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
        Routing.RegisterRoute("HomePage", typeof(HomePage));
        Routing.RegisterRoute("ShoppingCart", typeof(ShoppingCart));
        Routing.RegisterRoute("UserInfo", typeof(UserInfoPage));
        Routing.RegisterRoute("Accessories", typeof(Accessories));
        Routing.RegisterRoute("Leotards", typeof(Leotards));
        Routing.RegisterRoute("Women", typeof(Women));
        Routing.RegisterRoute("Men", typeof(Men));
        Routing.RegisterRoute("DancingShoes", typeof(DancingShoes));


    }
}
