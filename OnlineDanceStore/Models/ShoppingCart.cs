using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDanceStore.Models
{
  public  class ShoppingCart
    {
        static ShoppingCart Instance;
        public List<Item> Cart { get; set; }=new List<Item>();
        public double? TotalPrice { get => CalculatePrice(); }


        private ShoppingCart()
        {
           
        }

        public static ShoppingCart CreateShoppingCart()
        {
            if (Instance == null)
            {
                Instance = new ShoppingCart();
            }
            return Instance;
        }

        private double? CalculatePrice()
        {
           return Cart.Sum(x => x.Price);
        }
    }
}
