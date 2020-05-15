using System;

namespace ModuleVII
{
    internal static class Program
    {
        private static void Main()
        {
            BatAlgorithm a = new BatAlgorithm(2, Functions.Sphere);
            //BatAlgorithm b = new BatAlgorithm(2, Functions.Rastragin);
            //BatAlgorithm c = new BatAlgorithm(2, Functions.Shubert);
            //BatAlgorithm d = new BatAlgorithm(2, Functions.Stybinski);
            //BatAlgorithm e = new BatAlgorithm(2, Functions.SumSquares);

            Console.ReadKey();
        }
    }
}
