namespace Labirynth_Run
{
    using System;

    public class LabirynthRunner
    {
        private const string CellMarkFree = "0";
        private const string CellMarkStart = "*";
        private const string CellMarkTaken = "x";
        private const string CellMarkUnreachable = "u";

        private int rowsLastIndex;
        private int colsLastIndex;

        public LabirynthRunner()
        {
            this.Labirynth = new string[6, 6];
        }

        public string[,] Labirynth { get; set; }

        public void Start()
        {
            var startCell = new Cell(2, 1);
            var step = 0;

            this.BuildLabirynth();
            this.TraverseLabyrinth(startCell, step);
            this.PrintLabirynth();
        }

        public void TraverseLabyrinth(Cell currentCell, int step)
        {
            if (!this.IsInRange(currentCell))
            {
                return;
            }

            if (this.IsTaken(currentCell))
            {
                return;
            }

            if (this.IsNotForUpdate(currentCell, step))
            {
                return;
            }

            if (this.Labirynth[currentCell.X, currentCell.Y] != CellMarkStart)
            {
                this.Labirynth[currentCell.X, currentCell.Y] = step.ToString();
            }

            var left = new Cell(currentCell.X - 1, currentCell.Y);
            var right = new Cell(currentCell.X + 1, currentCell.Y);
            var top = new Cell(currentCell.X, currentCell.Y - 1);
            var bottom = new Cell(currentCell.X, currentCell.Y + 1);

            this.TraverseLabyrinth(left, step + 1);
            this.TraverseLabyrinth(right, step + 1);
            this.TraverseLabyrinth(top, step + 1);
            this.TraverseLabyrinth(bottom, step + 1);

            return;
        }

        private bool IsInRange(Cell cell)
        {
            return (cell.X >= 0 && cell.X < this.Labirynth.GetLength(0) && 
                    cell.Y >= 0 && cell.Y < this.Labirynth.GetLength(1));
        }

        private bool IsTaken(Cell cell)
        {
            return (this.Labirynth[cell.X, cell.Y] == CellMarkTaken);
        }

        private bool IsNotForUpdate(Cell cell, int step)
        {
            return (this.Labirynth[cell.X, cell.Y] != CellMarkStart && 
                    this.Labirynth[cell.X, cell.Y] != CellMarkFree && 
                    int.Parse(this.Labirynth[cell.X, cell.Y]) < step);
        }

        private void BuildLabirynth()
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

            this.rowsLastIndex = this.Labirynth.GetLength(0) - 1;
            this.colsLastIndex = this.Labirynth.GetLength(0) - 1;
        }

        private void PrintLabirynth()
        {
            for (int i = 0; i < this.Labirynth.GetLength(0); i++)
            {
                for (int j = 0; j < this.Labirynth.GetLength(1); j++)
                {
                    if (this.Labirynth[i, j] == CellMarkFree)
                    {
                        this.Labirynth[i, j] = CellMarkUnreachable;
                    }

                    Console.Write("{0} ", this.Labirynth[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}