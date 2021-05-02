using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class MaterialModel
    {
        public int materialid { get; set; }
        public double materialstockqty { get; set; }
        public string materialuom { get; set; }
        public string materialdesc { get; set; }
    }
}
