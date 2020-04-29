using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            BFSTest();
            DFSTest();

            Console.ReadKey();
        }

        private static void BFSTest()
        {
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            var graph = new GraphBD<int>(vertices, edges);

            Console.WriteLine(string.Join(", ", graph.BFS(1)));
            // 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        }

        private static void DFSTest()
        {
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            var graph = new GraphBD<int>(vertices, edges);

            Console.WriteLine(string.Join(", ", graph.DFS(1)));
            // 1, 3, 6, 5, 8, 9, 10, 7, 4, 2
        }

    }
}
