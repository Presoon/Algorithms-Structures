using System;

namespace ModuleVII
{
    internal static class Program
    {
        private static void Main()
        {
            BeeAlgorithm a = new BeeAlgorithm(2, Functions.Sphere);
            //BeeAlgorithm b = new BeeAlgorithm(2, Functions.Rastragin);
            //BeeAlgorithm c = new BeeAlgorithm(2, Functions.Shubert);
            //BeeAlgorithm d = new BeeAlgorithm(2, Functions.Stybinski);
            //BeeAlgorithm e = new BeeAlgorithm(2, Functions.SumSquares);

            Console.ReadKey();
        }
    }
}
