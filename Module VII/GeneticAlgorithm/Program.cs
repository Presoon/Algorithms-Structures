using System;

namespace ModuleVII
{
    internal static class Program
    {
        private static void Main()
        {

            GeneticAlgorithm a = new GeneticAlgorithm(2, Functions.Sphere);
            //GeneticAlgorithm b = new GeneticAlgorithm(2, Functions.Rastragin);
            //GeneticAlgorithm c = new GeneticAlgorithm(2, Functions.Shubert);
            //GeneticAlgorithm d = new GeneticAlgorithm(2, Functions.Stybinski);
            //GeneticAlgorithm e = new GeneticAlgorithm(2, Functions.SumSquares);

            Console.ReadKey();
        }
    }
}
