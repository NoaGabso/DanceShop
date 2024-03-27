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
    public class ShoppingCartViewModel : ViewModel
    {
        #region Fields
        Models.ShoppingCart cart;
        
        ObservableCollection<Item> items;
       
        #region Properties


        public ObservableCollection<Item> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChange(nameof(Items));
            }
        }

        public double? TotalPrice
        {
            get => cart.TotalPrice;
        }
        #endregion
            #endregion
            #region Service component
        private readonly OnlineDanceStoreServices _service;
        #endregion
        #region Commands 
        public ICommand RemoveFromCartCommand { get; protected set; }
        public ICommand ShowPriceCommand { get; protected set; }
        public ICommand OrderCommand { get; protected set; }

        #endregion
       public ShoppingCartViewModel(OnlineDanceStoreServices service, Models.ShoppingCart cart)
        {
            _service = service;
            this.cart = cart;
          
            Items = new ObservableCollection<Item>(cart.Cart);

            RemoveFromCartCommand = new Command<Item>(async (item) => {
             cart.Cart.Remove(item);Items.Remove(item); await AppShell.Current.DisplayAlert(" המוצר נמחק מהרשימה", "", "אישור");
            OnPropertyChange(nameof(TotalPrice));

                OrderCommand = new Command(async () => await CreateOrder());
            });
        }

        private async Task CreateOrder()
        {
            var loggeduser = await SecureStorage.Default.GetAsync("LoggedUser");
            User user = JsonSerializer.Deserialize<User>(loggeduser);
            Order order = new Order() { DateOreder = DateTime.Now, Items = cart.Cart, User = user, Price = cart.TotalPrice };
            bool success = await _service.CreateOrder(order);
            if (success)
            {
                cart.Cart = null;
                items.Clear();
                { await AppShell.Current.DisplayAlert("ההזמנה בוצעה בהצלחה", "", "אישור"); }
                await AppShell.Current.GoToAsync("UserInfo"); //לעבור למסך הזמנות

            }
            else
                await AppShell.Current.DisplayAlert("ההזמנה לא בוצעה", "", "שגיאה");
        
        
    }

        public async Task Refresh()
        {
            Items.Clear();
            if(cart.Cart.Count > 0)
            {
                foreach(var item in cart.Cart) 
                {
                    Items.Add(item);
                }
            }
                OnPropertyChange(nameof(TotalPrice));
        }

        




    }
}
