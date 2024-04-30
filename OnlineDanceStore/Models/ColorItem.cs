using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDanceStore.Models
{
    public class ColorItem
    {
        public int ColorItemId { get; set; } 
        public string ColorName { get; set; }
        public ColorItem() { }

        //public ColorItem(int id, string name) 
        //{ ColorItemId = id;
        //    ColorName = name;
        //}  
    }
}
