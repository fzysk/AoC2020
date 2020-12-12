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

            foreach (string[] generatedData in GenerateFixUpData(data))
            {
                bool success = true;
                int i = 0, accumulate = 0;
                var operationsDone = new Dictionary<int, string>();

                while (i < generatedData.Length)
                {
                    // check break condition
                    if (operationsDone.ContainsKey(i))
                    {
                        success = false;
                        break;
                    }

                    // add line as processed
                    operationsDone.Add(i, generatedData[i]);

                    // process line
                    (Operations op, int modifier) = ProcessLine(generatedData[i]);

                    switch (op)
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

                if (success)
                {
                    Console.WriteLine(accumulate);
                    return;
                }
            }
        }

        private static (Operations op, int modifier) ProcessLine(string line)
        {
            Operations op = (Operations)Enum.Parse(typeof(Operations), line.Substring(0, 3));
            int modifier = int.Parse(line.Substring(4, line.Length - 4));

            return (op, modifier);
        }

        static IEnumerable<string[]> GenerateFixUpData(string[] originalData)
        {
            for (int i = 0; i < originalData.Length; i++)
            {
                (Operations op, int modifier) = ProcessLine(originalData[i]);

                if (op == Operations.jmp)
                {
                    originalData[i] = originalData[i].Replace("jmp", "nop");
                    
                    // let's try this data
                    yield return originalData;

                    // rollback
                    originalData[i] = originalData[i].Replace("nop", "jmp");
                }
                else if (op == Operations.nop && !(modifier == 0 || modifier == 1))
                {
                    originalData[i] = originalData[i].Replace("nop", "jmp");

                    // let's try this one
                    yield return originalData;

                    // rollback
                    originalData[i] = originalData[i].Replace("jmp", "nop");
                }
            }

            throw new Exception("Got to the end, changed everything");
        }
    }
}
