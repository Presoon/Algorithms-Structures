using System;


namespace Graphs
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Tests();
            Console.ReadKey();
        }

        private static void Tests()
        {
            int[,] adjacencyMatrix = {
                { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                { 0, 0, 4, 0, 10, 0, 2, 0, 0 },
                { 0, 0, 0, 14, 0, 2, 0, 1, 6 },
                { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };

            GraphFD graph = new GraphFD(adjacencyMatrix);

            Console.WriteLine(graph.DijkstraPath(1, 9));
            Console.WriteLine(graph.FloydPath(3));
        }
    }
}
