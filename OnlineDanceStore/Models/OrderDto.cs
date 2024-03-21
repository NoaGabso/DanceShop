using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDanceStore.Models
{
     public class OrderDto
    {
        public Order Order { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
