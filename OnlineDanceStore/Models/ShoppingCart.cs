using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDanceStore.Models
{
  public  class ShoppingCart
    {
        
        public List<Item> Cart { get; set; }=new List<Item>();
        public double? TotalPrice { get => CalculatePrice(); }


        public ShoppingCart()
        {
           
        }

        

        public double? CalculatePrice()
        {
           return Cart.Sum(x => x.Price);
            
        }
    }
}
