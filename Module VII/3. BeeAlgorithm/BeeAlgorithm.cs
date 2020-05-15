using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleVII
{
    internal class BeeAlgorithm
    {
        private const int LimitOfGenerations = 100;
        private const int PopSize = 100;
        private const int MinOfX = -10;
        private const int MaxOfX = 10;
        private readonly List<Point> _beeList;
        private readonly double[] _begin;
        private readonly double[] _end;
        private readonly int _dim;

        public BeeAlgorithm(int dim, Func<double[], double> function)
        {
            _dim = dim;
            _begin = new double[dim];
            _end = new double[dim];

            for (int i = 0; i < dim; i++)
            {
                _begin[i] = MinOfX;
                _end[i] = MaxOfX;
            }

            _beeList = GenerateList();

            int generation = 0;
            while (generation < LimitOfGenerations)
            {
                _beeList = Sort(_beeList, function);

                var P = new List<double>();
                double sum = 0;
                for (int i = 0; i < PopSize; i++)
                    sum += function(_beeList[i].Arg);
                for (int i = 0; i < PopSize; i++)
                    P.Add((function(_beeList[i].Arg)) / sum);

                Random rand = new Random();
                for (int i = 0; i < PopSize; i++)
                {
                    double p = rand.NextDouble();
                    if (p < P[i])
                        _beeList[i] = Move(_beeList[i]);
                }

                Console.WriteLine($"\nGeneracja: {generation}");
                for (int i = 0; i < _beeList.Count; i++)
                    Console.WriteLine($"{i}. {_beeList[i]} {function(_beeList[i].Arg)}");
                Console.WriteLine();

                generation++;
            }

            Console.WriteLine($"Wartośc minimalna: {function(_beeList[0].Arg)} w ({_beeList[0]})");
        }


        private List<Point> GenerateList()
        {
            var list = new List<Point>();
            for (int i = 0; i < PopSize; i++)
                list.Add(Point.GetRandomPoint(_begin, _end, MinOfX, MaxOfX));

            return list;
        }

        private Point Move(Point p)
        {
            var args = new double[_dim];

            Random rand = new Random();

            int k = rand.Next(PopSize);

            for (int i = 0; i < _dim; i++)
            {
                double alpha = rand.NextDouble() * 2 - 1;
                double beta = rand.NextDouble();

                double delta = p.Arg[i] - _beeList[k].Arg[i];

                args[i] = p.Arg[i] + alpha * beta * delta;
            }

            return new Point(args);
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