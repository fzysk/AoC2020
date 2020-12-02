using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            IEnumerable<Record> records = input.Select(x => new Record(x));

            Console.WriteLine(records.Count(r => r.IsPasswordValid()));
            Console.WriteLine(records.Count(r => r.IsPasswordUltraValid()));
            Console.ReadKey();
        }
    }
}
