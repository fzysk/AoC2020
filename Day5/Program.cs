using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day5
{
    class Program
    {
        private static readonly Regex passRegex = new Regex("([FB]{7})([RL]{3})");

        private const char ROWS_BINARY_ONE = 'B';
        private const char COLUMNS_BINARY_ONE = 'R';
        private const int BINARY_BASE = 2;

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            List<BoardingPass> passes = input.Select(line => LineToBoardingPass(line)).OrderBy(pass => pass.GetSeatID()).ToList();

            // PART 1 - Get max (spoiler, it's 832)
            Console.WriteLine(passes[passes.Count - 1].GetSeatID());

            // PART 2 - Get our seat id
            for (int i = 1; i < passes.Count; i++)
            {
                if (passes[i].GetSeatID() - passes[i - 1].GetSeatID() > 1)
                {
                    Console.WriteLine($"Our seat id is somewhere in between {passes[i - 1].GetSeatID()} " +
                        $"and {passes[i].GetSeatID()}");
                    return;
                }
            }
        }

        static BoardingPass LineToBoardingPass(string line)
        {
            Match match = passRegex.Match(line);

            int row = GetRow(match.Groups[1].Value);
            int column = GetColumn(match.Groups[2].Value);

            return new BoardingPass(row, column);
        }

        private static int GetRow(string value)
        {
            return CalculateBinaryValue(value, ROWS_BINARY_ONE);
        }

        private static int GetColumn(string value)
        {
            return CalculateBinaryValue(value, COLUMNS_BINARY_ONE);
        }

        private static int CalculateBinaryValue(string value, char binaryOne)
        {
            int result = 0;
            for (int i = value.Length - 1, j = 0; i >= 0; i--, j++)
            {
                if (value[i] == binaryOne)
                {
                    result += (int)Math.Pow(BINARY_BASE, j);
                }
            }

            return result;
        }
    }
}
