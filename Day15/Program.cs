using System;
using System.Collections.Generic;
using System.Linq;

namespace Day15
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = "6,4,12,1,20,0,16";

            Dictionary<int, int> valueToLastOccurenceDict = new Dictionary<int, int>();
            List<int> startData = data.Split(',').Select(x => int.Parse(x)).ToList();
            List<int> turns = startData.ToList();
            InitDictionary(valueToLastOccurenceDict, turns);
            
            int turn = turns.Count, endTurn = 30_000_000;
            while (turn < endTurn)
            {
                int previousTurn = turn - 1;
                int newNumber = -1, previousNumber = turns[previousTurn];

                if (valueToLastOccurenceDict.TryGetValue(previousNumber, out int lastOccurance) && startData.Count - 1 != previousTurn)
                {
                    newNumber = previousTurn - lastOccurance;
                    valueToLastOccurenceDict[previousNumber] = previousTurn;
                }
                else
                {
                    newNumber = 0;

                    if (startData.Count() - 1 != previousTurn)
                    {
                        valueToLastOccurenceDict.Add(previousNumber, previousTurn);
                    }
                }

                turns.Add(newNumber);
                turn++;
            }

            // PART 1
            Console.WriteLine(turns[2020 - 1]);

            // PART 2
            Console.WriteLine(turns[endTurn - 1]);
        }

        private static void InitDictionary(Dictionary<int, int> valueToLastOccurenceDict, List<int> turns)
        {
            for (int i = 0; i < turns.Count; i++)
            {
                valueToLastOccurenceDict.Add(turns[i], i);
            }
        }
    }
}
