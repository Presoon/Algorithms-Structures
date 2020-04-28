using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyclical_List
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Element first = new Element("First");
            Element second = new Element("Second");
            Element third = new Element("Third");
            Element fourth = new Element("Fourth");

            CycList cycList = new CycList();
            cycList.Add(first);
            cycList.Add(second);
            Console.WriteLine(first.Previous.Value);
            cycList.Add(third);
            cycList.Add(fourth);
            Console.WriteLine(first.Previous.Value);

            cycList.Get();
            cycList.RemoveAt(0);
            cycList.Get();
            cycList.RemoveAt(1);
            cycList.Get();
            cycList.RemoveAt(0);
            cycList.Get();
            Console.WriteLine("Is there any elements in list?: " + cycList.Check().ToString());
            Console.Read();
        }
    }
}
