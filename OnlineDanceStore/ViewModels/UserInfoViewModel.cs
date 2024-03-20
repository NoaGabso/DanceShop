using OnlineDanceStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OnlineDanceStore.Models;
using OnlineDanceStore.View;
using System.Text.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace OnlineDanceStore.ViewModels
{
    public class UserInfoViewModel:ViewModel
    {
        #region Properties
       
        public ObservableCollection<Item> Items { get; set; }
        public ObservableCollection<ObservableCollection<Item>> orders { get; set; }
        #endregion
        #region Service component
        private readonly OnlineDanceStoreServices _service;
        #endregion
        public UserInfoViewModel(OnlineDanceStoreServices service) { }
    }
}
