using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day9
{
    class Program
    {
        private const int PREAMBLE_SIZE = 25;

        static void Main(string[] args)
        {
            long[] numbers = File.ReadAllLines("input.txt").Select(x => long.Parse(x)).ToArray();

            for (int i = 0; i < numbers.Length - PREAMBLE_SIZE; i++)
            {
                long[] preamble = numbers.Skip(i).Take(PREAMBLE_SIZE).ToArray();

                if (!IsSumTwoFromArray(preamble, numbers[PREAMBLE_SIZE + i]))
                {
                    Console.WriteLine(numbers[PREAMBLE_SIZE + i]);
                    return;
                }
            }
        }

        private static bool IsSumTwoFromArray(long[] preamble, long testedNumber)
        {
            for (int i = 0; i < preamble.Length - 1; i++)
            {
                for (int j = i + 1; j < preamble.Length; j++)
                {
                    if (preamble[i] + preamble[j] == testedNumber)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
