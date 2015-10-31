namespace Labirynth_Run
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LabirynthRunner
    {
        //private const string CellMarkFree = "0";
        //private const string CellMarkTaken = "X";
        //private const string CellMarkStart = "*";

        //private int RowsLastIndex;
        //private int ColsLastIndex;

        //public LabirynthRunner()
        //{
        //    this.Labirynth = new string[6, 6];
        //    this.VisitedCells = new List<Cell>();

        //    this.BuildLabirynth();
        //}

        //public string[,] Labirynth { get; set; }

        //public IList<Cell> VisitedCells { get; set; }

        //public void Start()
        //{
        //    var startCell = new Cell(2, 1);

        //    this.VisitedCells.Add(startCell);
        //    this.TraverseLabyrinth(this.VisitedCells, startCell);

        //    for (int i = 0; i < this.Labirynth.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < this.Labirynth.GetLength(1); j++)
        //        {
        //            Console.Write("{0} ", this.Labirynth[i,j]);
        //        }

        //        Console.WriteLine();
        //    }
        //}

        //public void TraverseLabyrinth(IList<Cell> visitedCells, Cell currentCell)
        //{
        //    // Movement Priority => Left, Top, Right, Bottom
        //    Cell nextCell = null;

        //    if (this.CanMoveLeft(currentCell))
        //    {
        //        nextCell = new Cell(currentCell.X - 1, currentCell.Y);
        //        this.VisitedCells.Add(nextCell);

        //        this.TraverseLabyrinth(this.VisitedCells, nextCell);
        //    }

        //    if (this.CanMoveTop(currentCell))
        //    {
        //        nextCell = new Cell(currentCell.X, currentCell.Y - 1);
        //        this.VisitedCells.Add(nextCell);

        //        this.TraverseLabyrinth(this.VisitedCells, nextCell);
        //    }

        //    if (this.CanMoveRight(currentCell))
        //    {
        //        nextCell = new Cell(currentCell.X + 1, currentCell.Y);
        //        this.VisitedCells.Add(nextCell);

        //        this.TraverseLabyrinth(this.VisitedCells, nextCell);
        //    }

        //    if (this.CanMoveBottom(currentCell))
        //    {
        //        nextCell = new Cell(currentCell.X, currentCell.Y + 1);
        //        this.VisitedCells.Add(nextCell);

        //        this.TraverseLabyrinth(this.VisitedCells, nextCell);
        //    }

        //    if(nextCell != null)
        //    {
        //        var currentPositionSymbol = this.Labirynth[nextCell.X, nextCell.Y];
        //        var cellValue = -1;
        //        int.TryParse(currentPositionSymbol.ToString(), out cellValue);

        //        if (currentPositionSymbol != CellMarkStart)
        //        {
        //            if(currentPositionSymbol == CellMarkFree)
        //            {
        //                this.Labirynth[nextCell.X, nextCell.Y] = Convert.ToString(this.VisitedCells.Count);
        //            }
        //            else if(currentPositionSymbol != CellMarkFree && cellValue > this.VisitedCells.Count)
        //            {
        //                this.Labirynth[nextCell.X, nextCell.Y] = Convert.ToString(this.VisitedCells.Count);
        //            }
        //        }
        //    }

        //    this.VisitedCells.RemoveAt(this.VisitedCells.Count - 1);
        //    return;
        //}

        //public void BuildLabirynth()
        //{
        //    var rows = 0;

        //    Labirynth[rows, 0] = CellMarkFree;
        //    Labirynth[rows, 1] = CellMarkFree;
        //    Labirynth[rows, 2] = CellMarkFree;
        //    Labirynth[rows, 3] = CellMarkTaken;
        //    Labirynth[rows, 4] = CellMarkFree;
        //    Labirynth[rows, 5] = CellMarkTaken;

        //    rows += 1;

        //    Labirynth[rows, 0] = CellMarkFree;
        //    Labirynth[rows, 1] = CellMarkTaken;
        //    Labirynth[rows, 2] = CellMarkFree;
        //    Labirynth[rows, 3] = CellMarkTaken;
        //    Labirynth[rows, 4] = CellMarkFree;
        //    Labirynth[rows, 5] = CellMarkTaken;

        //    rows += 1;

        //    Labirynth[rows, 0] = CellMarkFree;
        //    Labirynth[rows, 1] = CellMarkStart;
        //    Labirynth[rows, 2] = CellMarkTaken;
        //    Labirynth[rows, 3] = CellMarkFree;
        //    Labirynth[rows, 4] = CellMarkTaken;
        //    Labirynth[rows, 5] = CellMarkFree;

        //    rows += 1;

        //    Labirynth[rows, 0] = CellMarkFree;
        //    Labirynth[rows, 1] = CellMarkTaken;
        //    Labirynth[rows, 2] = CellMarkFree;
        //    Labirynth[rows, 3] = CellMarkFree;
        //    Labirynth[rows, 4] = CellMarkFree;
        //    Labirynth[rows, 5] = CellMarkFree;

        //    rows += 1;

        //    Labirynth[rows, 0] = CellMarkFree;
        //    Labirynth[rows, 1] = CellMarkFree;
        //    Labirynth[rows, 2] = CellMarkFree;
        //    Labirynth[rows, 3] = CellMarkTaken;
        //    Labirynth[rows, 4] = CellMarkTaken;
        //    Labirynth[rows, 5] = CellMarkFree;

        //    rows += 1;

        //    Labirynth[rows, 0] = CellMarkFree;
        //    Labirynth[rows, 1] = CellMarkFree;
        //    Labirynth[rows, 2] = CellMarkFree;
        //    Labirynth[rows, 3] = CellMarkTaken;
        //    Labirynth[rows, 4] = CellMarkFree;
        //    Labirynth[rows, 5] = CellMarkTaken;

        //    this.RowsLastIndex = this.Labirynth.GetLength(0) - 1;
        //    this.ColsLastIndex = this.Labirynth.GetLength(0) - 1;
        //}

        //private bool IsNotVisited(IList<Cell> visitedCells, Cell nextCell)
        //{
        //    var isAlreadyVisited = visitedCells.Any(cell => cell.X == nextCell.X && cell.Y == nextCell.Y);

        //    return !isAlreadyVisited;
        //}

        //private bool CanMoveLeft(Cell currentCell)
        //{
        //    var nextCell = new Cell(currentCell.X - 1, currentCell.Y);
        //    var isNotVisited = this.IsNotVisited(this.VisitedCells, nextCell);

        //    return (nextCell.X >= 0 &&
        //        Labirynth[nextCell.X, nextCell.Y] != CellMarkTaken &&
        //        isNotVisited);
        //}

        //private bool CanMoveRight(Cell currentCell)
        //{
        //    var nextCell = new Cell(currentCell.X + 1, currentCell.Y);
        //    var isNotVisited = this.IsNotVisited(this.VisitedCells, nextCell);

        //    return (nextCell.X <= this.RowsLastIndex &&
        //        Labirynth[nextCell.X, nextCell.Y] != CellMarkTaken &&
        //        isNotVisited);
        //}

        //private bool CanMoveTop(Cell currentCell)
        //{
        //    var nextCell = new Cell(currentCell.X, currentCell.Y - 1);
        //    var isNotVisited = this.IsNotVisited(this.VisitedCells, nextCell);

        //    return (nextCell.Y >= 0 &&
        //        Labirynth[nextCell.X, nextCell.Y] != CellMarkTaken &&
        //        isNotVisited);
        //}

        //private bool CanMoveBottom(Cell currentCell)
        //{
        //    var nextCell = new Cell(currentCell.X, currentCell.Y + 1);
        //    var isNotVisited = this.IsNotVisited(this.VisitedCells, nextCell);

        //    return (nextCell.Y <= this.ColsLastIndex &&
        //        Labirynth[nextCell.X, nextCell.Y] != CellMarkTaken &&
        //        isNotVisited);
        //}
        private const int StartCellValue = -2;
        private const int WallCellValue = -1;
        private const int EmptyCellValue = 0;

        [STAThread]
        public static void Main()
        {

            FillMazeWithPaths(maze, maze.StartingCell.Row, maze.StartingCell.Col, 1);
            Console.WriteLine(maze);
        }

        private static void FillMazeWithPaths(Maze maze, int row, int col, int step)
        {
            if (!IsInRange(row, col, maze.Rows, maze.Cols))
            {
                return;
            }

            if (maze[row, col] == WallCellValue)
            {
                return;
            }

            if (maze[row, col] != StartCellValue && maze[row, col] != EmptyCellValue && step > maze[row, col])
            {
                return;
            }

            maze[row, col] = step;

            FillMazeWithPaths(maze, row - 1, col, step + 1);
            FillMazeWithPaths(maze, row + 1, col, step + 1);
            FillMazeWithPaths(maze, row, col - 1, step + 1);
            FillMazeWithPaths(maze, row, col + 1, step + 1);
        }

        private static bool IsInRange(int row, int col, int mazeRows, int mazeCols)
        {
            var inRowRange = row >= 0 && row < mazeRows;
            var inColRange = col >= 0 && col < mazeCols;

            return inRowRange && inColRange;
        }
    }
}