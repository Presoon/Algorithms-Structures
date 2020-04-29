using System;

namespace Graphs
{
    public class GraphFD
    {
        private int[,] AdjacencyMatrix { get; set; }
        private const int CST = 9999;

        public GraphFD(int[,] adjacencyMatrix)
        {
            AdjacencyMatrix = adjacencyMatrix;
        }

        public string FloydPath(int stop)
        {
            var distance = new int[stop, stop];

            for (int i = 0; i < stop; ++i)
                for (int j = 0; j < stop; ++j)
                    distance[i, j] = AdjacencyMatrix[i, j];

            for (int k = 0; k < stop; ++k)
            {
                for (int i = 0; i < stop; ++i)
                {
                    for (int j = 0; j < stop; ++j)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                            distance[i, j] = distance[i, k] + distance[k, j];
                    }
                }
            }
            return ToString(distance, stop);
        }

        public string DijkstraPath(int start, int stop)
        {
            var distance = new int[stop];
            var shortestPathTreeSet = new bool[stop];

            for (int i = 0; i < stop; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }
            distance[start] = 0;

            for (int count = 0; count < stop - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, stop);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < stop; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(AdjacencyMatrix[u, v]) && distance[u] != int.MaxValue && distance[u] + AdjacencyMatrix[u, v] < distance[v])
                        distance[v] = distance[u] + AdjacencyMatrix[u, v];
            }

            return ToString(distance, stop);
        }

        private static string ToString(int[,] distance, int verticesCount)
        {
            string output = "";

            for (int i = 0; i < verticesCount; ++i)
            {
                for (int j = 0; j < verticesCount; ++j)
                {
                    if (distance[i, j] == CST)
                        output += "cst".PadLeft(7);
                    else
                        output += distance[i, j].ToString().PadLeft(7);
                }

                output += "\n";
            }

            return output;
        }

        private static string ToString(int[] distance, int verticesCount)
        {
            string output = "";

            for (int i = 0; i < verticesCount; ++i)
                output += ($"{i} : {distance[i]} \n");

            return output;
        }

        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] != false || distance[v] > min) continue;
                min = distance[v];
                minIndex = v;
            }

            return minIndex;
        }

    }
}