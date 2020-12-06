using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            int yesCount = 0;
            foreach (IEnumerable<string> answerGroup in GetGroupedAnswers(input))
            {
                var answerDict = new Dictionary<char, int>();
                foreach (string answers in answerGroup)
                {
                    foreach (char answer in answers)
                    {
                        if (!answerDict.ContainsKey(answer))
                        {
                            answerDict.Add(answer, 0);
                        }
                    }
                }

                yesCount += answerDict.Keys.Count;
            }

            Console.WriteLine(yesCount);
        }

        private static IEnumerable<IEnumerable<string>> GetGroupedAnswers(string[] input)
        {
            int prevBreak = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == "")
                {
                    yield return input.Skip(prevBreak).Take(i - prevBreak);
                    prevBreak = i + 1;
                }
            }

            yield return input.Skip(prevBreak);
        }
    }
}
