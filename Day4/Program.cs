using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int validPassports = SplitData(input).Select(data => PassportParser.Parse(data)).Count(passport => passport.IsPassportValid());

            Console.WriteLine(validPassports);
        }

        static IEnumerable<IEnumerable<string>> SplitData(string[] input)
        {
            int prevBreak = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == "")
                {
                    yield return input.Skip(prevBreak).Take(i - prevBreak);
                    prevBreak = i+1;
                }
            }
        }
    }
}
