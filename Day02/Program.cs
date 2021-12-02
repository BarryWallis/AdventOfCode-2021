﻿// See https://aka.ms/new-console-template for more information
namespace Day02 // Note: actual namespace depends on the project name.
{
    public class Program
    {
        enum Direction { Forward, Down, Up };

        static private int _horizontal;
        static public int Horizontal
        {
            get => _horizontal;
            set => _horizontal = value >= 0
                ? value
                : throw new ArgumentOutOfRangeException(nameof(Horizontal), "Must be non-negative.");
        }

        static private int _depth;
        static public int Depth
        {
            get => _depth;
            set => _depth = value >= 0
                ? value
                : throw new ArgumentOutOfRangeException(nameof(Depth), "Must be non-negative.");
        }

        public static void Main()
        {
            string? line;
            while ((line = Console.ReadLine()) is not null)
            {
                (Direction direction, int units)  = ParseLine(line);
                switch (direction)
                {
                    case Direction.Forward:
                        Horizontal += units;
                        break;
                    case Direction.Down:
                        Depth += units;
                        break;
                    case Direction.Up:
                        Depth -= units;
                        break;
                    default:
                        throw new InvalidOperationException("Unknown direction.");
                }
            }

            Console.WriteLine($"Result: {Horizontal * Depth}");
        }

        private static (Direction direction, int units) ParseLine(string line)
        {
            string[] args = line.Split(null);
            return !Enum.TryParse(args[0], ignoreCase: true, out Direction direction)
                ? throw new InvalidOperationException("Unknown direction.")
                : !int.TryParse(args[1], out int units)
                ? throw new InvalidOperationException("Units musst be a non-negative integer.")
                : (direction, units);
        }
    }
}