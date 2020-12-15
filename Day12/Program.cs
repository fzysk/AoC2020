using Day12.Directions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Direction> directions = File.ReadAllLines("input.txt").Select(line => Direction.CreateDirection(line)).ToList();

            Direction direction = new East();
            foreach (Direction nextDirection in directions)
            {
                direction = direction.Apply(nextDirection);
            }

            Console.WriteLine(direction.GetManhattanDistanceFromStartingPoint());
        }
    }
}
