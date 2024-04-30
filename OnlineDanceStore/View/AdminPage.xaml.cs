using OnlineDanceStore.ViewModels;

namespace OnlineDanceStore.View;

public partial class AdminPage : ContentPage
{
    public AdminPage(AdminPageViewModel vm)
	{
        this.BindingContext = vm;

        InitializeComponent();
	}
}