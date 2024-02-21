using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDanceStore.Models
{
    public class Item
    {
        public Categories Categories { get; set; } = null!;
        public SubCategory SubCategory { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public Gender Gender {  get; set; }
        public SizeItem SizeItem { get; set; }
        public ColorItem ColorItem { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public string ItemImage {  get; set; }
    }
}
