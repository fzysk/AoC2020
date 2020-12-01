using System;
using System.IO;

namespace Day1
{
    class Program
    {
        const string C_INPUT_PATH = "input.txt";
        const int C_EXPECTED_RESULT = 2020;

        static void Main(string[] args)
        {
            string[] fileContent = File.ReadAllLines(C_INPUT_PATH);
            (int a, int b) = Part1(fileContent);
            (int c, int d, int e) = Part2(fileContent);

            Console.WriteLine(a * b);
            Console.WriteLine(c * d * e);
            Console.ReadKey();
        }

        private static (int, int) Part1(string[] fileContent)
        {
            for (int i = 0; i < fileContent.Length; i++)
            {
                for (int j = i + 1; j < fileContent.Length; j++)
                {
                    int a = int.Parse(fileContent[i]);
                    int b = int.Parse(fileContent[j]);

                    if (a + b == C_EXPECTED_RESULT)
                    {
                        return (a, b);
                    }
                }
            }

            return (-1, -1);
        }

        private static (int c, int d, int e) Part2(string[] fileContent)
        {
            int length = fileContent.Length;
            if (length < 3)
            {
                throw new ArgumentException("Input length should be at least 3", nameof(fileContent));
            }

            for (int i = 0; i < length; i++)
            {
                int c = int.Parse(fileContent[i]);
                for (int j = i + 1; j < length; j++)
                {
                    int d = int.Parse(fileContent[j]);
                    for (int k = j + 1; k < length; k++)
                    {
                        int e = int.Parse(fileContent[k]);

                        if (c + d + e == C_EXPECTED_RESULT)
                        {
                            return (c, d, e);
                        }
                    }
                }
            }

            return (-1, -1, -1);
        }
    }
}
