using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class FGOne
    {
        public int id { get; set; }
        public int fgid { get; set; }
        public string fgdescription { get; set; }
        public int rawmatsid { get; set; }
        public double rawmatsqty { get; set; }
        public string rawmatsuom { get; set; }
    }
}
