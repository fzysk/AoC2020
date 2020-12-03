using System;
using System.IO;

namespace Day3
{
    public class Program
    {
        private const char TREE = '#';

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            Console.WriteLine(SlideThroughTrees(input, 1, 1));
            Console.WriteLine(SlideThroughTrees(input, 3, 1));
            Console.WriteLine(SlideThroughTrees(input, 5, 1));
            Console.WriteLine(SlideThroughTrees(input, 7, 1));
            Console.WriteLine(SlideThroughTrees(input, 1, 2));
            Console.WriteLine();
            Console.WriteLine("Second number is answer for the first part");
            Console.WriteLine("Multiply those values to get answer for the second part");
        }

        /// <summary>
        /// Counts how many trees toboggan slided through by sliding from (0,0) to past bottom of the map
        /// </summary>
        /// <param name="slope">The slope</param>
        /// <param name="xSpeed">How many indexes toboggan goes right every step</param>
        /// <param name="ySpeed">How many indexes toboggan goes down every step</param>
        /// <returns>How many trees were met during the slide</returns>
        public static int SlideThroughTrees(string[] slope, int xSpeed, int ySpeed)
        {
            int treeCount = 0;
            int slopeInitWidth = slope[0].Length;
            double curX = 0, curY = 0;
            double angle = xSpeed / (1.0 * ySpeed);

            while (curY < slope.Length)
            {
                if (curX % 1.0 == 0)
                {
                    // check if we slided through a tree
                    if (slope[(int)curY][(int)curX % slopeInitWidth] == TREE)
                    {
                        treeCount++;
                    }
                }

                curX += angle;
                curY++;
            }

            return treeCount;
        }
    }
}
