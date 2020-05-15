using System;

namespace ModuleVII
{
    public static class Functions
    {
        public static double Sphere(params double[] x)
        {
            int n = x.Length;
            double y = 0;

            for (int i = 0; i < n; i++)
                y += Math.Pow(x[i], 2);

            return y;
        }

        public static double SumSquares(params double[] x)
        {
            int n = x.Length;
            double y = 0;

            for (int i = 0; i < n; i++)
                y += i*Math.Pow(x[i], 2);

            return y;
        }

        public static double Shubert(params double[] x)
        {
            int n = x.Length;
            double y = 1;
            double yy = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    yy += i * Math.Cos((i + 1) * x[i]);
                }
                y *= yy;
            }
            return y;
        }

        public static double Rastragin(params double[] x)
        {
            int n = x.Length;
            double y = 10 * n;

            for (int i = 0; i < n; i++)
                y += Math.Pow(x[i], 2) - 10 * Math.Cos(2 * Math.PI * x[i]);

            return y;
        }

        public static double Stybinski(params double[] x)
        {
            int n = x.Length;
            double y = 0;

            for (int i = 0; i < n; i++)
                y += Math.Pow(x[i], 4) - 16 * Math.Pow(x[i], 2) + 5 * x[i];

            return y / 2;
        }


    }
}