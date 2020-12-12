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
    }
}
