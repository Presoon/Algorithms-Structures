using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleVII
{
    internal class GeneticAlgorithm
    {
        private const int LimitOfGenerations = 10;
        private const int PopSize = 50;
        private const int ArgMin = -10;
        private const int ArgMax = 10;
        private static readonly int PopToCross = Convert.ToInt32(PopSize * 0.9);
        private readonly double[] _begin;
        private readonly double[] _end;
        private readonly int _dim;

        public GeneticAlgorithm(int dim, Func<double[], double> function)
        {
            _dim = dim;
            _begin = new double[dim];
            _end = new double[dim];

            for (int i = 0; i < dim; i++)
            {
                _begin[i] = ArgMin;
                _end[i] = ArgMax;
            }

            var popList = GenerateList();
            popList = Sort(popList, function);

            int generation = 0;

            while (generation < LimitOfGenerations)
            {
                for (int i = 0; i < PopToCross; i++)
                    for (int j = 0; j < PopToCross; j++)
                        if (IsCross())
                        {
                            Point mom = popList[i];
                            Point dad = popList[j];
                            popList.Add(Mutation(Crossing(mom, dad)));
                        }

                popList = Sort(popList, function);

                popList.RemoveRange(PopSize, popList.Count - PopSize);

                Console.WriteLine($"\nGeneracja: {generation}");
                for (int i = 0; i < popList.Count; i++)
                    Console.WriteLine($"{i}. {popList[i]} {function(popList[i].Arg)}");
                Console.WriteLine();

                generation++;
            }

            Console.WriteLine($"Wartość minimalna: {function(popList[0].Arg)} w ({popList[0]})");
        }

        private static bool IsCross()
        {
            Random rand = new Random();

            double p1 = rand.NextDouble();
            double p2 = rand.NextDouble();

            return p1 < p2;
        }

        private Point Crossing(Point mom, Point dad)
        {
            var args = new double[_dim];

            for (int i = 0; i < _dim; i++)
            {
                Random rand = new Random();
                double p1 = rand.NextDouble();
                double p2 = 1 - p1;
                args[i] = (mom.Arg[i] * p1 + dad.Arg[i] * p2);
            }

            return new Point(args);
        }

        private Point Mutation(Point point)
        {
            var args = new double[_dim];

            for (int i = 0; i < _dim; i++)
            {
                Random rand = new Random();
                double mutationRate = rand.NextDouble() + 0.5;

                args[i] = point.Arg[i] * mutationRate;
            }

            return new Point(args);
        }

        private List<Point> GenerateList()
        {
            var list = new List<Point>();

            for (int i = 0; i < PopSize; i++)
                list.Add(Point.GetRandomPoint(_begin, _end, ArgMin, ArgMax));

            return list;
        }

        private static List<Point> Sort(List<Point> list, Func<double[], double> function)
        {
            var values = list.Select(t => function(t.Arg)).ToList();

            for (int i = 0; i < values.Count - 1; i++)
            {
                for (int j = 0; j < values.Count - 1; j++)
                {
                    if (!(values[j] > values[j + 1])) continue;
                    double temp = values[j];
                    Point p = list[j];

                    values[j] = values[j + 1];
                    list[j] = list[j + 1];

                    values[j + 1] = temp;
                    list[j + 1] = p;
                }
            }
            return list;
        }

    }
}