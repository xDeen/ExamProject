using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models.Initialize
{
    public class Init
    {
        

        public List<FGThree> InitializeFGThree()
        {
            var fgthree = new List<FGThree>()
            {
                new FGThree(){ id = 1, fgthreeid= 1, fgthreedesc = "Tire", fgtwomatsid = 1, fgtwomatsqty = 1, fgtwouom = "pcs"  },
                new FGThree(){ id = 2, fgthreeid= 1, fgthreedesc = "Tire", fgtwomatsid = 2, fgtwomatsqty = 1, fgtwouom = "pcs"  },
                new FGThree(){ id = 3, fgthreeid= 1, fgthreedesc = "Tire", fgtwomatsid = 3, fgtwomatsqty = 1, fgtwouom = "pcs"  },
            };

            return fgthree;
        }
        public List<FGTwo> InitializeFGTwo()
        {
            var fgtwo = new List<FGTwo>() {
                new FGTwo() {id = 1, fgtwoid = 1, fgdescription = "Tread", fgonematsid = 1, fgoneqty = 2, rawmatsid = 0, rawmatsqty = 0, rawmatsuom = "kgs"},
                new FGTwo() {id = 2, fgtwoid = 2, fgdescription = "Beadwires", fgonematsid = 1, fgoneqty = 0.25, rawmatsid = 0, rawmatsqty = 0, rawmatsuom = "kgs"},
                new FGTwo() {id = 3, fgtwoid = 2, fgdescription = "Beadwires", fgonematsid = 0, fgoneqty = 0, rawmatsid = 7, rawmatsqty = 0.5, rawmatsuom = "kgs"},
                new FGTwo() {id = 4, fgtwoid = 3, fgdescription = "Ply", fgonematsid = 1, fgoneqty = 0.4, rawmatsid = 0, rawmatsqty = 0, rawmatsuom = "kgs"},
                new FGTwo() {id = 5, fgtwoid = 4, fgdescription = "Ply", fgonematsid = 0, fgoneqty = 0, rawmatsid = 1, rawmatsqty = 0.6, rawmatsuom = "kgs"}


            };

            return fgtwo;
        }
        public List<FGOne> InitializeFGOne()
        {
            var fgone = new List<FGOne>()
            {
                new FGOne() { id = 1,fgid = 1,fgdescription = "Final Rubber", rawmatsid = 2, rawmatsqty = 0.8  },
                new FGOne() { id = 2,fgid = 1,fgdescription = "Final Rubber", rawmatsid = 3, rawmatsqty = 0.1  },
                new FGOne() { id = 3,fgid = 1,fgdescription = "Final Rubber", rawmatsid = 4, rawmatsqty = 0.02  },
                new FGOne() { id = 4,fgid = 1,fgdescription = "Final Rubber", rawmatsid = 5, rawmatsqty = 0.04  },
                new FGOne() { id = 5,fgid = 1,fgdescription = "Final Rubber", rawmatsid = 6, rawmatsqty = 0.06 }

            };

            return fgone;
        }
        public List<MaterialModel> InitializeMaterials()
        {

            var materials = new List<MaterialModel>() {
                new MaterialModel() { materialid = 1, materialdesc = "Nylon", materialuom = "kgs", materialstockqty = 100.00 },
                new MaterialModel() { materialid = 2, materialdesc = "Natural Rubber", materialuom = "kgs", materialstockqty = 100.00 },
                new MaterialModel() { materialid = 3, materialdesc = "Synthetic Rubber", materialuom = "kgs", materialstockqty = 100.00 },
                new MaterialModel() { materialid = 4, materialdesc = "Chemical #1", materialuom = "grams", materialstockqty = 100.00 },
                new MaterialModel() { materialid = 5, materialdesc = "Chemical #2", materialuom = "grams", materialstockqty = 100.00 },
                new MaterialModel() { materialid = 6, materialdesc = "Chemical #3", materialuom = "grams", materialstockqty = 100.00 },
                new MaterialModel() { materialid = 7, materialdesc = "Wire", materialuom = "kgs", materialstockqty = 100.00 }
            };

            return materials;
        }
    }
}
