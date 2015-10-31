namespace Labirynth_Run
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