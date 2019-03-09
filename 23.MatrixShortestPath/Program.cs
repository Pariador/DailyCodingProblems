using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        bool[,] board = 
        {
            { false, false, false, false },
            { true,  true,  false, true  },
            { false, false, false, false },
            { false, false, false, false },
        };

        Position from = new Position(3, 0);
        Position to = new Position(0, 0);

        int distance = ShortestPath(board, from, to, out int[,] distances);

        Console.WriteLine($"Shortest path: {distance}");

        Print(distances, board);
    }

    static int ShortestPath(bool[,] board, Position from, Position to, out int[,] distances)
    {
        distances = GetDistances(board.GetLength(0), board.GetLength(1));
        distances[from.Row, from.Col] = 0;

        var queue = new Queue<Position>();
        var visited = new HashSet<Position>();
        queue.Enqueue(from);
        visited.Add(from);

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

            neighbors = neighbors.Where(neighbor =>
            {
                return 0 <= neighbor.Row && neighbor.Row < board.GetLength(0) &&
                    0 <= neighbor.Col && neighbor.Col < board.GetLength(1) &&
                    !board[neighbor.Row, neighbor.Col];
            }).ToArray();

            foreach (var neighbor in neighbors)
            {
                int distance = distances[current.Row, current.Col] + 1;

                if (distance < distances[neighbor.Row, neighbor.Col])
                {
                    distances[neighbor.Row, neighbor.Col] = distance;
                }

                if 
                (
                    visited.Contains(neighbor)
                )
                {
                    continue;
                }

                queue.Enqueue(neighbor);
                visited.Add(neighbor);
            }
        }

        return distances[to.Row, to.Col];
    }

    static int[,] GetDistances(int rows, int cols)
    {
        int[,] distances = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                distances[row, col] = int.MaxValue;
            }
        }

        return distances;
    }

    static void Print(int[,] distances, bool[,] board)
    {
        const string Format = "{0:d2}";

        StringBuilder result = new StringBuilder();

        int rows = distances.GetLength(0);
        int cols = distances.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            int distance = distances[row, 0];
            if (board[row, 0])
            {
                distance = -1;
            }

            result.Append(string.Format(Format, distance).PadLeft(3, ' '));

            for (int col = 1; col < cols; col++)
            {
                distance = distances[row, col];
                if (board[row, col])
                {
                    distance = -1;
                }

                result.Append(", " + string.Format(Format, distance).PadLeft(3, ' '));
            }

            result.AppendLine();
        }

        Console.Write(result.ToString());
    }
}