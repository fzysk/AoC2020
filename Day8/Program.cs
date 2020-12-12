using System;
using System.Collections.Generic;
using System.IO;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = File.ReadAllLines("input.txt");
            var operationsDone = new Dictionary<int, char>();

            int i = 0, accumulate = 0;

            while (i < data.Length)
            {
                // check break condition
                if (operationsDone.ContainsKey(i))
                {
                    break;
                }

                // add line as processed
                operationsDone.Add(i, '\0');

                // process line
                string op = data[i].Substring(0, 3);
                int modifier = int.Parse(data[i].Substring(4, data[i].Length - 4));

                switch ((Operations)Enum.Parse(typeof(Operations), op))
                {
                    case Operations.nop:
                        i++;
                        break;
                    case Operations.acc:
                        accumulate += modifier;
                        i++;
                        break;
                    case Operations.jmp:
                        i += modifier;
                        break;
                    default:
                        throw new InvalidOperationException("Operation not handled");
                }
            }

            Console.WriteLine(accumulate);
        }
    }
}
