
using OnlineDanceStore.ViewModels;
using OnlineDanceStore.View;

namespace OnlineDanceStore.View;

public partial class LoadingPage : ContentPage
{
    public LoadingPage(LoadingPageViewModel vm)
    {
        this.BindingContext = vm;
        InitializeComponent();

    }
}
