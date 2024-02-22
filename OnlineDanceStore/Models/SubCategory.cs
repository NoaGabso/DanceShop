using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDanceStore.Models
{
    public class SubCategory
    {
        public int? CategoryId { get; set; }
        public Categories Category { get; set; }
        public int SubCategoryId {  get; set; }
        public string SubcategoryName { get; set; }
    }
}
