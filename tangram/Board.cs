using System;
using System.Diagnostics;
using System.Transactions;
using tangram;

internal class Board : ICloneable
{
    public static List<Board> solutions = new List<Board>();

    public List<Frame> frames = new List<Frame>();

    int[,] matrix;
    internal int Width = 0, Height = 0;

    public Board(int width, int height)
    {
        this.Width = width;
        this.Height = height;
        this.matrix = new int[width, height];
        for (int x = 0; x < this.Width; x++)
        {
            for (int y = 0; y < this.Height; y++)
            {
                this.matrix[x, y] = 0;
            }
        }
    }
    internal bool IsSolved()
    {
        for (int y = 0; y < this.Height; y++)
        {
            for (int x = 0; x < this.Width; x++)
            {
                if (this.matrix[x, y] == 0) return false;

            }
        }
        return true;
    }

    internal bool Add(Turn turn, int x, int y)
    {
        // fast bound checks
        if (x + turn.Width > this.Width) return false;
        if (y + turn.Height > this.Height) return false;

        // try add shape, if a pixel fails, exit
        for (int sx = 0; sx < turn.Width; sx++)
        {
            for (int sy = 0; sy < turn.Height; sy++)
            {
                if (turn.matrix[sx, sy] > 0 && this.matrix[x + sx, y + sy] > 0)
                {
                    return false;
                }
            }
        }

        // since we have not exited yet, we can add
        for (int sx = 0; sx < turn.Width; sx++)
        {
            for (int sy = 0; sy < turn.Height; sy++)
            {
                this.matrix[x + sx, y + sy] += turn.matrix[sx, sy];
            }
        }

        frames.Add(new Frame(turn, x, y));
        return true;
    }

    public object Clone()
    {
        var board = new Board(this.Width, this.Height);
        for (int x = 0; x < this.Width; x++)
        {
            for (int y = 0; y < this.Height; y++)
            {
                board.matrix[x, y] = this.matrix[x, y];
            }
        }
        return board;
    }

    bool debug_flag = false;

    internal bool Solve(Tile[] shapes, int depth_debug = 0)
    {
        for (int i = 0; i < shapes.Length; i++)
        {
            foreach (var variation in shapes[i].Turns)
            {
                for (int y = 0; y < this.Height; y++)
                {
                    for (int x = 0; x < this.Width; x++)
                    {
                        var board2 = (Board)this.Clone();

                        if (board2.Add(variation, x, y))
                        {
                            var shapes2 = shapes.getCopyExceptOfElementAt(i);
                            if (board2.Solve(shapes2, depth_debug + 1))
                            {
                                solutions.Add(board2);

                                board2.Print();
                            }
                        }
                    }
                }
            }
        }

        return this.IsSolved();
    }

    internal void Print()
    {
        for (int y = 0; y < this.Height; y++)
        {
            for (int x = 0; x < this.Width; x++)
            {
                int color = this.matrix[x, y];
                var consoleColor = ConsoleColor.Black;
                switch (color)
                {
                    case 1: consoleColor = ConsoleColor.Blue; break;
                    case 2: consoleColor = ConsoleColor.Yellow; break;
                    case 3: consoleColor = ConsoleColor.Green; break;
                    case 4: consoleColor = ConsoleColor.Magenta; break;
                    case 5: consoleColor = ConsoleColor.DarkYellow; break;
                    case 6: consoleColor = ConsoleColor.DarkGray; break;
                    case 7: consoleColor = ConsoleColor.Gray; break;
                    default: consoleColor = ConsoleColor.Black; break;
                }
                Console.BackgroundColor = consoleColor;
                Console.Write("  ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");
        }
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("--------------------------");

    }
}