using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = File.ReadAllLines("input.txt");

            PartOne(data);
            PartTwo(data);
        }

        private static void PartOne(string[] data)
        {
            Regex regex = new Regex(@"\d+");
            int earliestDepart = int.Parse(data[0]);
            List<int> busIds = regex.Matches(data[1]).Select(match => int.Parse(match.Value)).ToList();

            int chosenBusId = -1;
            int minAwaitingTime = int.MaxValue;
            foreach (int busId in busIds)
            {
                if (earliestDepart % busId != 0)
                {
                    int busesPast = earliestDepart / busId;
                    int nextAvailableTime = busId * (busesPast + 1);

                    int awaitingTime = nextAvailableTime - earliestDepart;

                    if (minAwaitingTime > awaitingTime)
                    {
                        minAwaitingTime = awaitingTime;
                        chosenBusId = busId;
                    }
                }
            }

            Console.WriteLine(chosenBusId * minAwaitingTime);
        }

        private static void PartTwo(string[] data)
        {
            // x are converted to -1 for easier reference
            int[] busesWithX = data[1].Split(',').Select(x => int.TryParse(x, out int a) ? a : -1).ToArray();

            int[] buses = busesWithX.Where(bus => bus > 0).ToArray();
            int[] offsets = new int[buses.Length];

            // init offsets
            // offset[0] = 0
            int offset = 1;
            for (int i = 1, j = 1; i < busesWithX.Length; i++)
            {
                if (busesWithX[i] > 0)
                {
                    offsets[j++] = offset;
                }
                offset++;
            }

            long multiplier = buses[0];
            int currentId = 1;

            for (long timestamp = multiplier; timestamp < long.MaxValue; timestamp += multiplier)
            {
                bool success = true;
                for (int i = 0; i <= currentId; i++)
                {
                    if ((timestamp + offsets[i]) % buses[i] != 0)
                    {
                        success = false;
                        break;
                    }
                }

                if (success)
                {
                    if (currentId == buses.Length - 1)
                    {
                        Console.WriteLine(timestamp);
                        return;
                    }

                    multiplier *= buses[currentId];
                    currentId++;
                }
            }
        }
    }
}
