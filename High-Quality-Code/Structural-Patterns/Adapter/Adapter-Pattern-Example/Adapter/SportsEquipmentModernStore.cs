using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class SportsEquipmentModernStore : ISportsEquipment
    {
        public SportsEquipmentModernStore()
        {
            this.LegacyStore = new SportsEquipmentLegacyStore();
        }

        private SportsEquipmentLegacyStore LegacyStore { get; set; }
        
        public void GetEquipment(EquipmentProperties properties)
        {
            StringBuilder equipment = new StringBuilder();

            equipment.Append(this.LegacyStore.GetGloves(properties.GlovesSize));
            equipment.Append(Environment.NewLine);
            equipment.Append(this.LegacyStore.GetShoes(properties.ShoesSize, properties.ShoesBrand));
            equipment.Append(Environment.NewLine);
            equipment.Append(this.LegacyStore.GetPants(properties.PantsSize, properties.PantsType));
            equipment.Append(Environment.NewLine);

            Console.WriteLine(equipment.ToString());
        }
    }
}
