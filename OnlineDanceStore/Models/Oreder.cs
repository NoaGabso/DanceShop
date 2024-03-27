using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDanceStore.Models
{
    
      public class Order
    {
       public List<Item> Items { get; set; }    
        public User User { get; set; }
        public DateTime DateOreder {  get; set; }
        public double? TotalPrice { get; set; }

    }
}
