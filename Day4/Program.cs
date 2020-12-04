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
            var passports = SplitData(input).Select(data => PassportParser.Parse(data)).Where(passport => passport.IsPassportValid());

            foreach (var pass in passports)
            {
                Console.WriteLine(pass);
            }
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
