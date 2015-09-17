using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class EquipmentProperties
    {
        public EquipmentProperties(string glovesSize, string shoesSize, string shoesBrand, string pantsSize, string pantsType)
        {
            this.GlovesSize = glovesSize;
            this.ShoesSize = shoesSize;
            this.ShoesBrand = shoesBrand;
            this.PantsSize = pantsSize;
            this.PantsType = pantsType;
        }

        public string GlovesSize { get; set; }

        public string ShoesSize { get; set; }

        public string ShoesBrand { get; set; }

        public string PantsSize { get; set; }

        public string PantsType { get; set; }
    }
}
