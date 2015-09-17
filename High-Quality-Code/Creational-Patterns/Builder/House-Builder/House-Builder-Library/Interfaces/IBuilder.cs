using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace House_Builder_Library
{
    public interface IBuilder
    {
        void BuildFoundations();

        void BuildElectricitySystem();

        void BuildWaterSystem();

        void BuildInterior();

        void BuildCeiling();
    }
}
