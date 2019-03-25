using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

static class Program
{
    const char Live = '*';
    const char Dead = '.';

    static readonly int[][] Neighbors =
    {
        new int[] { 1, 0 },
        new int[] { -1, 0 },
        new int[] { 0, 1 },
        new int[] { 0, -1 },

        new int[] { 1, 1 },
        new int[] { -1, -1 },
        new int[] { -1, 1 },
        new int[] { 1, -1 },
    };

    static void Main()
    {
        var board = ReadBoard();

        GameOfLife(board, 200, 100);
    }

    static void GameOfLife(bool[,] board, int steps, int delay)
    {
        SetTerminalSize(board);

        var next = new bool[board.GetLength(0), board.GetLength(1)];

        int step = 0;
        do
        {
            Render(board);
            NextState(board, next);

            var hold = board;
            board = next;
            next = hold;

            step++;

            Thread.Sleep(delay);
        } while (step < steps);

        Console.WriteLine("\nThe GAME OF LIFE is done and now the universe has halted.");
        Console.ReadKey(true);

        Console.Clear();
    }

    static void NextState(bool[,] current, bool[,] next)
    {
        for (int row = 0; row < current.GetLength(0); row++)
        {
            for (int col = 0; col < current.GetLength(1); col++)
            {
                int living = CountLivingNeighbors(current, row, col);

                if (current[row, col] && (living < 2 || 3 < living))
                {
                    next[row, col] = false;
                }
                else if (!current[row, col] && living == 3)
                {
                    next[row, col] = true;
                }
                else
                {
                    next[row, col] = current[row, col];
                }
            }
        }
    }

    static int CountLivingNeighbors(bool[,] board, int row, int col)
    {
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);

        int living = 0;

        foreach (var neighbor in Neighbors)
        {
            int neighborRow = row + neighbor[0];
            int neighborCol = col + neighbor[1];

            if
            (
                (0 <= neighborRow && neighborRow < rows) &&
                (0 <= neighborCol && neighborCol < cols) &&
                board[neighborRow, neighborCol]
            )
            {
                living++;
            }
        }

        return living;
    }

    static void Render(bool[,] board)
    {
        var result = new StringBuilder();

        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                char cell = board[row, col] ? Live : Dead;

                result.Append(cell);
            }

            result.AppendLine();
        }

        Console.Clear();
        Console.Write(result.ToString());
    }

    static bool[,] FromPositions(int[][] positions)
    {
        int minRow = positions.Select(pos => pos[0]).Min();
        int maxRow = positions.Select(pos => pos[0]).Max();
        int minCol = positions.Select(pos => pos[1]).Min();
        int maxCol = positions.Select(pos => pos[1]).Max();

        int rows = maxRow - minRow + 1;
        int cols = maxCol - minCol + 1;

        var board = new bool[rows, cols];

        foreach (var position in positions)
        {
            board[position[0] - minRow, position[1] - minCol] = true;
        }

        return board;
    }

    static bool[,] ReadBoard(string file = "board.txt") 
    {
        string[] lines = File.ReadAllLines(file);

        bool[,] board = new bool[lines.Length, lines[0].Length];

        for (int row = 0; row < lines.Length; row++)
        {
            for (int col = 0, cols = lines[row].Length; col < cols; col++)
            {
                if (lines[row][col] == Live)
                {
                    board[row, col] = true;
                }
                else if (lines[row][col] == Dead)
                {
                    board[row, col] = false;
                }
            }
        }

        return board;
    }

    static void SetTerminalSize(bool[,] board)
    {
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);

        Console.WindowHeight = rows + 2;
        Console.WindowWidth = cols + 1;
        Console.BufferHeight = rows + 2;
        Console.BufferWidth = cols + 1;
    }
}