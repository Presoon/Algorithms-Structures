using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleVII
{
    internal class BatAlgorithm
    {
        private const int LimitOfGeneration = 10;
        private const int PopSize = 100;
        private const int MinOfX = -10;
        private const int MaxOfX = 10;
        private const int MinV = -2;
        private const int MaxV = 2;
        private readonly List<Point> _batList;
        private readonly List<Point> _velocityList;
        private readonly List<double> _distance = new List<double>();
        private readonly double[] _begin;
        private readonly double[] _end;
        private readonly int _dim;
        private const double E = 0.75;
        private const double Correction = 0.5;

        public BatAlgorithm(int dim, Func<double[], double> fun)
        {
            _dim = dim;
            _begin = new double[dim];
            _end = new double[dim];

            for (int i = 0; i < dim; i++)
            {
                _begin[i] = MinOfX;
                _end[i] = MaxOfX;
            }

            _batList = GenerateList(MinOfX, MaxOfX);
            _velocityList = GenerateList(MinV, MaxV);

            int generation = 0;

            while (generation < LimitOfGeneration)
            {
                Sort(fun);
                Point leader = _batList[0];

                for (int i = 1; i < PopSize; i++)
                    _distance.Add(GetDistance(leader, _batList[i]));

                for (int i = 1; i < PopSize; i++)
                    _batList[i] = Move(_batList[i], _velocityList[i], _distance[i - 1]);

                for (int i = 1; i < PopSize; i++)
                    _velocityList[i] = GetVelocity(_velocityList[i], _batList[i], leader);

                Sort(fun);

                Console.WriteLine($"\nGeneracja: {generation}");
                Console.WriteLine($"{0}. {_batList[0]} {fun(_batList[0].Arg)}");
                for (int i = 1; i < _batList.Count; i++)
                {
                    Console.WriteLine($"{i}. {_batList[i]} {fun(_batList[i].Arg)} {_distance[i - 1]}");
                }
                Console.WriteLine();
                generation++;
            }
            Console.WriteLine($"Wartość minimalna: {fun(_batList[0].Arg)} w ({_batList[0]})");
        }

        private List<Point> GenerateList(int min, int max)
        {
            var list = new List<Point>();

            for (int i = 0; i < PopSize; i++)
                list.Add(Point.GetRandomPoint(_begin, _end, min, max));

            return list;
        }

        private void Sort(Func<double[], double> fun)
        {
            var values = _batList.Select(t => fun(t.Arg)).ToList();

            for (int i = 0; i < values.Count - 1; i++)
            {
                for (int j = 0; j < values.Count - 1; j++)
                {
                    if (!(values[j] > values[j + 1])) continue;
                    double temp = values[j];
                    Point p = _batList[j];
                    Point v = _velocityList[j];

                    values[j] = values[j + 1];
                    _batList[j] = _batList[j + 1];
                    _velocityList[j] = _velocityList[j + 1];

                    values[j + 1] = temp;
                    _batList[j + 1] = p;
                    _velocityList[j + 1] = v;
                }
            }
        }

        private double GetDistance(Point leader, Point x)
        {
            double dist = 0;

            for (int i = 0; i < _dim; i++)
                dist += Math.Pow(x.Arg[i] - leader.Arg[i], 2);

            return Math.Sqrt(dist);
        }

        private Point Move(Point p, Point v, double r)
        {
            var args = new double[_dim];

            Random rand = new Random();

            for (int i = 0; i < _dim; i++)
                if (r > Correction)
                    args[i] = Math.Max(Math.Min(p.Arg[i] + (-1) * rand.NextDouble(), MaxOfX), MinOfX);
                else
                    args[i] = Math.Max(Math.Min(p.Arg[i] + E * v.Arg[i], MaxOfX), MinOfX);

            return new Point(args);
        }

        private Point GetVelocity(Point v, Point x, Point leader)
        {
            var args = new double[_dim];

            for (int i = 0; i < _dim; i++)
                args[i] = v.Arg[i] + (x.Arg[i] - leader.Arg[i]);

            return new Point(args);
        }
    }

}