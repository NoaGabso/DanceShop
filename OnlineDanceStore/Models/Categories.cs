using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDanceStore.Models
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public string? CategoriesName { get; set; }

        public Categories() { }  
        public Categories(int categoryid, string categoryname) 
        {this.CategoriesName= categoryname;
            this.CategoryId= categoryid;
        }  
        

    }
}