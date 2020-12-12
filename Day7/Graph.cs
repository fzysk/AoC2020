using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    internal class Graph
    {
        public List<Vertex> Vertices { get; set; } = new List<Vertex>();

        public int HowManyColorBagsContain(string vertexName)
        {
            bool[] visited = new bool[Vertices.Count];
            DFS(Vertices.FindIndex(v => v.Name == vertexName), visited);

            return visited.Count(v => v) - 1;
        }

        private void DFS(int vertexIndex, bool[] visited)
        {
            visited[vertexIndex] = true;

            foreach (Edge edge in Vertices[vertexIndex].Edges)
            {
                int toIndex = Vertices.FindIndex(e => e.Name == edge.To.Name);

                if (!visited[toIndex])
                {
                    DFS(toIndex, visited);
                }
            }   
        }
    }
}
