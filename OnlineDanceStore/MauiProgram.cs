﻿using Microsoft.Extensions.Logging;
using OnlineDanceStore.Services;
using OnlineDanceStore.ViewModels;
using OnlineDanceStore.View;
using OnlineDanceStore.View.Categories;
using CommunityToolkit.Maui;

namespace OnlineDanceStore;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

        _ = builder.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("clothesfont.ttf", "mayafont");
                fonts.AddFont("Playlist-Script.otf", "myfont");
            }).UseMauiCommunityToolkitMediaElement();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<Models.ShoppingCart>();
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
		builder.Services.AddTransient<ShoppingCartViewModel>();
		builder.Services.AddTransient<ShoppingCart>();
		builder.Services.AddSingleton<UserInfoViewModel>();
		builder.Services.AddSingleton<UserInfoPage>();
		builder.Services.AddSingleton<CategoriesViewModel>();
		builder.Services.AddSingleton<Leotards>();
		builder.Services.AddSingleton<Accessories>(); 
		builder.Services.AddSingleton<Men>(); 
		builder.Services.AddSingleton<Women>(); 
		builder.Services.AddSingleton<DancingShoes> (); 
		builder.Services.AddSingleton<PopUpPage> (); 
		builder.Services.AddSingleton<AdminPage> (); 
		builder.Services.AddSingleton<AdminPageViewModel> ();
		//



		


        return builder.Build();
	}
}
