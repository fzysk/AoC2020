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

            var seatsSimulator = new SeatsSimulator(seats);
            seatsSimulator.Simulate();

            Console.WriteLine(seatsSimulator.NumberOfOccupiedSeats);
        }
    }
}
