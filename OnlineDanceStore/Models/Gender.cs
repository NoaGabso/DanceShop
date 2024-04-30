using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDanceStore.Models
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public Gender() { }
        public Gender(int id, string name)
        { GenderId = id;
            GenderName = name;
        }
    }
}
