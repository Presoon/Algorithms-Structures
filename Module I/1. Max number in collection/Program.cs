using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_number_in_collection
{
    class Program
    {

        private static void Main(string[] args)
        {
            var array = new float[] { 1, 5, 23, -1, -25, 5 };
            Console.WriteLine(FindMax(array));
            Console.ReadLine();
        }

        static float FindMax(float[] tab)
        {
            float max = tab[0];
            foreach (var t in tab)
            {
                if (t > max)
                {
                    max = t;
                }
            }
            return max;
        }

    }
}
