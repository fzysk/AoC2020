using System;
using System.IO;
using System.Linq;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = File.ReadAllLines("input.txt");

            Seat[][] seats = data.Select(line => line.Select(@char => SeatMapper.Map(@char)).ToArray()).ToArray();
            var part1 = new Part1Simulator(seats);
            part1.Simulate();
            Console.WriteLine(part1.NumberOfOccupiedSeats);

            seats = data.Select(line => line.Select(@char => SeatMapper.Map(@char)).ToArray()).ToArray();
            var part2 = new Part2Simulator(seats);
            part2.Simulate();
            Console.WriteLine(part2.NumberOfOccupiedSeats);
        }
    }
}
