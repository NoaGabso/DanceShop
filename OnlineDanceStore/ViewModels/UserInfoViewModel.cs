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
        #region Fields
        private int _userid;
        #endregion
        #region Properties

        public ObservableCollection<Item> Items { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
        #endregion
        #region Commands
        public ICommand GetOrdersByUserCommand { get; protected set; }
        #endregion
        #region Service component
        private readonly OnlineDanceStoreServices _service;
        #endregion
        public UserInfoViewModel(OnlineDanceStoreServices service) 
        {
            _service = service;
           
            GetOrdersByUserCommand = new Command(async () =>
            {
                try
                {
                    var listoforders = await _service.GetUserOrders(((App)(Application.Current)).UserinApp.Id);

                    Orders = new ObservableCollection<Order>(listoforders);
                    OnPropertyChange(nameof(Orders));
                }
                catch (Exception ex) { }
            });
        }
        public async Task Refresh()
        {
            Orders.Clear();
            if (Orders.Count > 0)
            {
                foreach (var item in Orders)
                {
                    Orders.Add(item);   
                }
            }
           
        }

    }
}
