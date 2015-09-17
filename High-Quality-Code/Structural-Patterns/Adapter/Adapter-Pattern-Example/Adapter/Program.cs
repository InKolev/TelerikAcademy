using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var sportsEquipmentStore = new SportsEquipmentModernStore();

            sportsEquipmentStore.GetEquipment(
                new EquipmentProperties(
                    "Large",
                    "43", "Underarmour",
                    "42", "Trousers"));
        }
    }
}
