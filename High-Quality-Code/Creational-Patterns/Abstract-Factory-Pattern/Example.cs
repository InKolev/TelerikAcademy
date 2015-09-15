using ShaxxLibrary.Interfaces;
using ShaxxLibrary.Interfaces.DragonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaxxLibrary.Interfaces
{
    public abstract class UnitManufacturer : IManufacturer
    {
        private int unitsManufactured;

        public UnitManufacturer()
        {
            this.UnitsManufactured = 0;
        }

        public int UnitsManufactured
        {
            get
            {
                return this.unitsManufactured;
            }
            private set
            {
                this.unitsManufactured = value;
            }
        }

        public IUnit CreateUnit(IUnit unitType)
        {
            var spawnedUnit = unitType.Spawn();
            this.UnitsManufactured += 1;

            return spawnedUnit;
        }
    }
}
