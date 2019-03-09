using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public const int Unvisited = -1;
    public const int Blocked = -2;

    static void Main()
    {
        int[,] board = 
        {
            { Unvisited, Unvisited, Unvisited, Unvisited },
            { Blocked,   Blocked,   Unvisited, Blocked  },
            { Unvisited, Unvisited, Unvisited, Unvisited },
            { Unvisited, Unvisited, Unvisited, Unvisited },
        };

        Position from = new Position(3, 0);
        Position to = new Position(0, 0);

        int distance = ShortestPath(board, from, to);

        Console.WriteLine($"Shortest path: {distance}");

        Console.WriteLine("\nBoard:");
        Print(board);
    }

    static int ShortestPath(int[,] board, Position from, Position to)
    {
        board[from.Row, from.Col] = 0;

        var queue = new Queue<Position>();
        queue.Enqueue(from);

        while (queue.Any())
        {
            Position current = queue.Dequeue();

            Position[] neighbors =
            {
                new Position(current.Row - 1, current.Col),
                new Position(current.Row + 1, current.Col),
                new Position(current.Row, current.Col + 1),
                new Position(current.Row, current.Col - 1),
            };

            foreach (var neighbor in neighbors)
            {
                if 
                (
                    neighbor.Row < 0 || board.GetLength(0) <= neighbor.Row ||
                    neighbor.Col < 0 || board.GetLength(1) <= neighbor.Col ||
                    board[neighbor.Row, neighbor.Col] == Blocked ||
                    board[neighbor.Row, neighbor.Col] != Unvisited
                )
                {
                    continue;
                }

                board[neighbor.Row, neighbor.Col] = board[current.Row, current.Col] + 1;
                if (neighbor.Equals(to))
                {
                    return board[to.Row, to.Col];
                }

                queue.Enqueue(neighbor);
            }
        }

        return board[to.Row, to.Col];
    }

    static void Print(int[,] board)
    {
        const string Format = "{0:d2}";
        const int PadLength = 3;
        const char PadChar = ' ';

        StringBuilder result = new StringBuilder();

        for (int row = 0; row < board.GetLength(0); row++)
        {
            result.Append(string.Format(Format, board[row, 0]).PadLeft(PadLength, PadChar));

            for (int col = 1; col < board.GetLength(1); col++)
            {
                result.Append("|" + string.Format(Format, board[row, col]).PadLeft(PadLength, PadChar));
            }

            result.AppendLine();
        }

        Console.Write(result.ToString());
    }
}