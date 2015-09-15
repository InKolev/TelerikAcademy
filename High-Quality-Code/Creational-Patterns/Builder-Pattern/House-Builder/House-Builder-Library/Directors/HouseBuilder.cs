using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Builder_Library
{
    public class HouseBuilder : IBuilder
    {
        private List<IBuildingPart> house;

        public HouseBuilder()
        {
            this.house = new List<IBuildingPart>();
        }

        public List<IBuildingPart> House
        {
            get
            {
                return new List<IBuildingPart>(this.house);
            }
            set
            {
                this.house = value;
            }
        }

        public void BuildFoundations()
        {
            var foundations = new Substruction();
            AddHousePart(foundations);
        }

        public void BuildElectricitySystem()
        {
            var electricitySystem = new ElectricitySystem();
            AddHousePart(electricitySystem);
        }

        public void BuildWaterSystem()
        {
            var waterSystem = new WaterSystem();
            AddHousePart(waterSystem);
        }

        public void BuildInterior()
        {
            var interior = new Interior();
            AddHousePart(interior);
        }

        public void BuildCeiling()
        {
            var ceiling = new Ceiling();
            AddHousePart(ceiling);
        }

        private void AddHousePart(IBuildingPart part)
        {
            this.House.Add(part);
        }
    }
}
