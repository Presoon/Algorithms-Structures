using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal static class Program
    {
        private static void Main()
        {
            Element first = new Element("First");
            Element second = new Element("Second");
            Element third = new Element("Third");
            Element fourth = new Element("Fourth");

            Stack stack = new Stack();

            stack.Add(first);
            stack.Add(second);
            stack.Add(third);
            stack.Add(fourth);
            stack.Get();
            stack.GetRemove();
            stack.Get();
            stack.Remove();
            stack.Get();
            stack.Remove();
            stack.Remove();

            Console.WriteLine("Is there any elements in stack?: " + stack.Check().ToString());
            Console.Read();
        }
    }
}
