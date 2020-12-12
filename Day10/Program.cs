using System;
using System.IO;
using System.Linq;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] adapters = File.ReadAllLines("input.txt").Select(x => int.Parse(x)).OrderBy(x => x).ToArray();

            // concat start and end values
            adapters = new int[] { 0 }.Concat(adapters).Concat(new int[] { adapters[adapters.Length - 1] + 3 }).ToArray();
            Part1(adapters);
            Part2(adapters);
        }

        private static void Part1(int[] adapters)
        {
            int oneStepCounter = 0, threeStepCounter = 0;
            for (int i = 0; i < adapters.Length - 1; i++)
            {
                int difference = adapters[i + 1] - adapters[i];

                switch (difference)
                {
                    case 1:
                        oneStepCounter++;
                        break;
                    case 2:
                        break;
                    case 3:
                        threeStepCounter++;
                        break;
                    default:
                        throw new Exception("Difference > 3");
                }
            }

            Console.WriteLine(oneStepCounter * threeStepCounter);
        }

        private static void Part2(int[] adapters)
        {
            int maxDiff = 3;
            long[] solutions = new long[adapters.Length];

            // start-off
            solutions[1] = 1;
            solutions[2] = 2;
            solutions[3] = 4;
            
            for (int i = 4; i < adapters.Length; i++)
            {
                // previous is always reachable
                solutions[i] += solutions[i - 1];

                if (adapters[i] - adapters[i - 2] <= maxDiff)
                {
                    solutions[i] += solutions[i - 2];
                }

                if (adapters[i] - adapters[i - 3] <= maxDiff)
                {
                    solutions[i] += solutions[i - 3];
                }
            }

            Console.WriteLine(solutions[solutions.Length - 2]);
        }
    }
}
