using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Output
    {
       
        public string description { get; set; }
        public decimal qty { get; set; }
        public string uom { get; set; }
        public int hasraw { get; set; }
    }
}
