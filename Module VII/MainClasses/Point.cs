using System;

namespace ModuleVII
{
    public class Point
    {
        public readonly double[] Arg;
        private readonly int _n;

        public Point(params double[] arg)
        {
            _n = arg.Length;
            Arg = arg;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < _n; i++)
                s += $"{Arg[i]}";
            return s;
        }

        public static Point GetRandomPoint(double[] start, double[] stop, int min, int max)
        {
            Random rand = new Random();
            int n = start.Length;
            var point = new double[n];

            for (int i = 0; i < n; i++)
            {
                if (stop[i] > max)
                    stop[i] = max;

                if (start[i] < min)
                    start[i] = min;

                point[i] = rand.NextDouble() * (stop[i] - start[i]) + start[i];
            }
            Point p = new Point(point);
            return p;
        }
    }
}