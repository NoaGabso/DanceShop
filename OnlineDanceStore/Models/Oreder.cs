using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDanceStore.Models
{
    
      public class Order
    {
        public int OrderId { get; set; }
        public List<Item> OrderItems { get; set; }    
        public User User { get; set; }
        public DateTime OrderDate {  get; set; }
        public double? TotalPrice { get; set; }
        public Order() 
        {
            OrderItems = new List<Item>();
        }

    }
}
