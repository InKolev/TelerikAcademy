namespace Labirynth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        private const char CellMarkFree = '0';
        private const char CellMarkTaken = 'X';
        private const char CellMarkStart = '*';

        public Program()
        {
            this.BuildLabirynth();
            this.VisitedCells = new List<Cell>();
        }

        public char[,] Labirynth { get; set; }

        public IList<Cell> VisitedCells { get; set; }

        public void BuildLabirynth()
        {
            var rows = 0;

            Labirynth[rows, 0] = CellMarkFree;
            Labirynth[rows, 1] = CellMarkFree;
            Labirynth[rows, 2] = CellMarkFree;
            Labirynth[rows, 3] = CellMarkTaken;
            Labirynth[rows, 4] = CellMarkFree;
            Labirynth[rows, 5] = CellMarkTaken;

            rows += 1;

            Labirynth[rows, 0] = CellMarkFree;
            Labirynth[rows, 1] = CellMarkTaken;
            Labirynth[rows, 2] = CellMarkFree;
            Labirynth[rows, 3] = CellMarkTaken;
            Labirynth[rows, 4] = CellMarkFree;
            Labirynth[rows, 5] = CellMarkTaken;

            rows += 1;

            Labirynth[rows, 0] = CellMarkFree;
            Labirynth[rows, 1] = CellMarkStart;
            Labirynth[rows, 2] = CellMarkTaken;
            Labirynth[rows, 3] = CellMarkFree;
            Labirynth[rows, 4] = CellMarkTaken;
            Labirynth[rows, 5] = CellMarkFree;

            rows += 1;

            Labirynth[rows, 0] = CellMarkFree;
            Labirynth[rows, 1] = CellMarkTaken;
            Labirynth[rows, 2] = CellMarkFree;
            Labirynth[rows, 3] = CellMarkFree;
            Labirynth[rows, 4] = CellMarkFree;
            Labirynth[rows, 5] = CellMarkFree;

            rows += 1;

            Labirynth[rows, 0] = CellMarkFree;
            Labirynth[rows, 1] = CellMarkFree;
            Labirynth[rows, 2] = CellMarkFree;
            Labirynth[rows, 3] = CellMarkTaken;
            Labirynth[rows, 4] = CellMarkTaken;
            Labirynth[rows, 5] = CellMarkFree;

            rows += 1;

            Labirynth[rows, 0] = CellMarkFree;
            Labirynth[rows, 1] = CellMarkFree;
            Labirynth[rows, 2] = CellMarkFree;
            Labirynth[rows, 3] = CellMarkTaken;
            Labirynth[rows, 4] = CellMarkFree;
            Labirynth[rows, 5] = CellMarkTaken;
        }

        public void TraverseLabyrinth(ICollection<Cell> visitedCells, Cell currentCell)
        {
            // Movement Priority => Left, Top, Right, Bottom
            if(currentCell.X -1 < 0 || Labirynth[currentCell.X-1,currentCell.Y] == '0')
            {

            }
        }

        private bool CanMoveLeft(Cell currentCell)
        {
            return (currentCell.X - 1 < 0 || Labirynth[currentCell.X - 1, currentCell.Y] == '0');
        }

        private bool CanMoveRight(Cell currentCell)
        {
            return (currentCell.X + 1 < this.Labirynth.GetLength(0) || Labirynth[currentCell.X - 1, currentCell.Y] == '0');
        }
    }
}
