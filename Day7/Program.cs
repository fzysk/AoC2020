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

            // PART 1
            Graph graph1 = CreateGraph(data, reversedEdges: true);
            Console.WriteLine(graph1.HowManyColorBagsHave("shiny gold"));

            // PART 2
            Graph graph2 = CreateGraph(data);
            Console.WriteLine(graph2.HowManyIndividualBagsContain("shiny gold"));
        }

        static Graph CreateGraph(string[] data, bool reversedEdges = false)
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

                        if (reversedEdges)
                        {
                            subV.Edges.Add(new Edge()
                            {
                                To = v,
                                Value = bags
                            });
                        }
                        else
                        {
                            v.Edges.Add(new Edge()
                            {
                                To = subV,
                                Value = bags
                            });
                        }
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
