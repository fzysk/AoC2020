using System;
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
            Regex regex = new Regex(@"\d+");
            string[] data = File.ReadAllLines("input.txt");

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
    }
}
