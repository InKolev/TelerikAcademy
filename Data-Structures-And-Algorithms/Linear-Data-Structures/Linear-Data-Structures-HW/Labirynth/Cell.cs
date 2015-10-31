using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynth
{
    public class Cell
    {
        public Cell(int xCoordinate, int yCoordinate)
        {
            this.X = xCoordinate;
            this.Y = yCoordinate;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
