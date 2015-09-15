using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Builder_Library
{
    public class HouseConstructor
    {
        public HouseConstructor()
        {

        }

        public void BuildHouse(IBuilder builder)
        {
            builder.BuildFoundations();
            builder.BuildElectricitySystem();
            builder.BuildWaterSystem();
            builder.BuildCeiling();
            builder.BuildInterior();
        }
    }
}
