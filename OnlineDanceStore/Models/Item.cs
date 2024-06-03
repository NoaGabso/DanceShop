using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDanceStore.Models
{
    public class Item
    {
        public int ItemId { get; set; } 
        public Categories Category { get; set; } 
        public SubCategory SubCategory { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public Gender Gender {  get; set; }
        public SizeItem SizeItem { get; set; }
        public ColorItem ColorItem { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public string ItemImage {  get; set; }

        public Item() { }   
        //public Item(string ItemName, string ItemDescription, Category Category, int Quantity, 
        //    double Price, string ItemImage, Gender Gender, SizeItem SizeItem, ColorItem ColorItem) 
        //{
        //    this.ItemName = ItemName;
        //    this.ItemDescription = ItemDescription;
        //    this.Category = Category;
        //    this.Quantity = Quantity;
        //    this.Price = Price;
        //    this.ItemImage = ItemImage;
        //    this.Gender = Gender;
        //    this.SizeItem = SizeItem;
        //    this.ColorItem = ColorItem;
        //    this.SubCategory = null;
        //}   
    }

}
