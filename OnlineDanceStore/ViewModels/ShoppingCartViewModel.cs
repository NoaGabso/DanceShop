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
    public class ShoppingCartViewModel:ViewModel
    {
        #region Fields
        private Item newitem;

        #region Properties
        public Item NewItem { get => newitem; set { newitem = value; } }
     
        public ObservableCollection<Item> Items { get; set; }
        #endregion
        #endregion
        #region Service component
        private readonly OnlineDanceStoreServices _service;
        #endregion
        #region Commands
      
        #endregion
      
    }
}
