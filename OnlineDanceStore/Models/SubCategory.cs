using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDanceStore.Models
{
    public class SubCategory
    {
        public Categories Category { get; set; }
        public int Id {  get; set; }
        public string Name { get; set; }
    }
}
