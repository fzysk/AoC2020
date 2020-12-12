using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    internal class Graph
    {
        public List<Vertex> Vertices { get; set; } = new List<Vertex>();

        public int HowManyColorBagsHave(string vertexName)
        {
            bool[] visited = new bool[Vertices.Count];
            DFS(Vertices.FindIndex(v => v.Name == vertexName), visited);

            return visited.Count(v => v) - 1;
        }

        private int DFS(int vertexIndex, bool[] visited = null, int? previousBags = null)
        {
            if (visited != null)
            {
                visited[vertexIndex] = true;
            }

            int sum = 0;
            foreach (Edge edge in Vertices[vertexIndex].Edges)
            {
                int toIndex = Vertices.FindIndex(e => e.Name == edge.To.Name);

                if (visited == null || !visited[toIndex])
                {
                    sum += DFS(toIndex, visited, edge.Value * (previousBags ?? 1));
                }
            }

            return sum + (previousBags ?? 0);
        }

        public int HowManyIndividualBagsContain(string vertexName)
        {
            // I should've write BFS, but here it is, DFS without visited array
            return DFS(Vertices.FindIndex(v => v.Name == vertexName));
        }
    }
}
