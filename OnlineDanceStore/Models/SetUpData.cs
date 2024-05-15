using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDanceStore.Models
{
    public class SetUpData
    {
        public List<Categories> Categories { get; set; }
        public List<ColorItem> ColorItems { get; set; }

        public List<Gender> Genders { get; set; }

        public List<SubCategory> SubCategories { get; set; }    

        public List<SizeItem> SizeItems { get; set; }   

        public SetUpData() { }  
    }
}
