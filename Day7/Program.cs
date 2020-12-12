using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = File.ReadAllLines("input.txt");
            Graph graph = CreateGraph(data);

            Console.WriteLine(graph.HowManyColorBagsContain("shiny gold"));
        }

        static Graph CreateGraph(string[] data)
        {
            Graph graph = new Graph();
            Regex regex = new Regex(@"(\d+ )?(\w+ \w+) bags?");

            foreach (string line in data)
            {
                MatchCollection matches = regex.Matches(line);

                // parse first match
                Vertex v = GetOrCreateVertex(graph, matches[0].Groups[2].Value);

                for (int i = 1; i < matches.Count; i++)
                {
                    Match match = matches[i];
                    string name = match.Groups[2].Value;

                    if (name != "no other")
                    {
                        Vertex subV = GetOrCreateVertex(graph, name);
                        int bags = int.Parse(match.Groups[1].Value);

                        subV.Edges.Add(new Edge()
                        {
                            To = v,
                            Value = bags
                        });
                    }
                }
            }

            return graph;
        }

        private static Vertex GetOrCreateVertex(Graph graph, string vertex)
        {
            Vertex v = graph.Vertices.FirstOrDefault(x => x.Name == vertex);

            if (v == null)
            {
                v = CreateVertex(vertex);
                graph.Vertices.Add(v);
            }

            return v;
        }

        private static Vertex CreateVertex(string name)
        {
            return new Vertex()
            {
                Edges = new List<Edge>(),
                Name = name
            };
        }
    }
}
