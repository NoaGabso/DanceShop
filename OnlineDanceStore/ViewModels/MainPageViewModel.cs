using OnlineDanceStore.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineDanceStore.ViewModels
{

    public class MainPageViewModel:ViewModel
    {
       
        public ICommand LoginCommand { get; protected set; }
        public ICommand RegisterCommand { get; protected set; }
        #region Fields
        private bool tabisVisible;//הסתרת הטאב הנוכחי
        #endregion

        #region Properties
        public bool IsVisible
        {
            get =>!tabisVisible;
            set
            {
                if (tabisVisible != value)
                {
                    tabisVisible = value; OnPropertyChange();
                }
            }
        }
        #endregion
        public MainPageViewModel()
        {
          
            //_service = service;
            //UserName = string.Empty;
            //Password = string.Empty;

            RegisterCommand = new Command(async () =>
            {
                await AppShell.Current.GoToAsync("Register");
               tabisVisible = true; 
            });
            LoginCommand = new Command(  async() =>
            {
                  await AppShell.Current.GoToAsync("Login");
                tabisVisible = true; 
                //ShowLoginError = false;//הסתרת שגיאת לוגין
                //try
                //{
                //    #region טעינת מסך ביניים
                //    var lvm = new LoadingPageViewModel() { IsBusy = true };
                //    await AppShell.Current.Navigation.PushModalAsync(new LoadingPage(lvm));
                //    #endregion
                //    var user = await _service.LogInAsync(UserName, Password);

                //    lvm.IsBusy = false;
                //    await Shell.Current.Navigation.PopModalAsync();
                //    if (!user.Success)
                //    {
                //        ShowLoginError = true;
                //        LoginErrorMessage = user.Message;
                //    }
                //    else
                //    {
                //        await AppShell.Current.DisplayAlert("התחברת", "אישור להתחלת משחק", "אישור");
                //        await SecureStorage.Default.SetAsync("LoggedUser", JsonSerializer.Serialize(user.User));
                //        await AppShell.Current.GoToAsync("Game");
                //    }



                //}
                //catch (Exception ex)
                //{

                //    Console.WriteLine(ex.Message);

                //    await AppShell.Current.Navigation.PopModalAsync();
                //}


            });

        }
        
    }
}
