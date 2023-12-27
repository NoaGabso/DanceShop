using Microsoft.Extensions.Logging;
using OnlineDanceStore.Services;
using OnlineDanceStore.ViewModels;
using OnlineDanceStore.View;

namespace OnlineDanceStore;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<RegisterPageViewModel>();
        builder.Services.AddSingleton<RegisterPage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginPageViewModels>();
		builder.Services.AddTransient<LoadingPageViewModel>();
		builder.Services.AddTransient<LoadingPage>();
		builder.Services.AddSingleton<OnlineDanceStoreServices>();
		builder.Services.AddSingleton<HomePageViewModel>();
		builder.Services.AddSingleton<HomePage>();
		builder.Services.AddSingleton<ShoppingCartViewModel>();
		builder.Services.AddSingleton<ShoppingCart>();
		builder.Services.AddSingleton<UserInfoViewModel>();
		builder.Services.AddSingleton<UserInfo>();
        



        return builder.Build();
	}
}
