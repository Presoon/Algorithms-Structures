using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
    public class GraphBD<T>
    {
        private Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        public GraphBD() { }

        public GraphBD(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var v in vertices)
            {
                AddVertex(v);
            }

            foreach (var e in edges)
            {
                AddEdge(e);
            }
        }

        private void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }

        private void AddEdge(Tuple<T, T> edge)
        {
            if (!AdjacencyList.ContainsKey(edge.Item1) || !AdjacencyList.ContainsKey(edge.Item2)) return;
            AdjacencyList[edge.Item1].Add(edge.Item2);
            AdjacencyList[edge.Item2].Add(edge.Item1);
        }

        public HashSet<T> BFS(T start)
        {
            var visited = new HashSet<T>();

            if (!AdjacencyList.ContainsKey(start))
                return visited;

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in AdjacencyList[vertex].Where(neighbor => !visited.Contains(neighbor)))
                    queue.Enqueue(neighbor);
            }

            return visited;
        }

        public HashSet<T> DFS(T start)
        {
            var visited = new HashSet<T>();

            if (!AdjacencyList.ContainsKey(start))
                return visited;

            var stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in AdjacencyList[vertex].Where(neighbor => !visited.Contains(neighbor)))
                    stack.Push(neighbor);
            }

            return visited;
        }
    }
}