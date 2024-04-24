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
   
            RegisterCommand = new Command(async () =>
            {
               IsVisible = true;
                await AppShell.Current.GoToAsync("Register");
               
            });
            LoginCommand = new Command(  async() =>
            {
                  IsVisible = true;
                await AppShell.Current.GoToAsync("Login");
                
            });

        }
        
    }
}
