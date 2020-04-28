using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Element first = new Element("First");
            Element second = new Element("Second");
            Element third = new Element("Third");
            Element fourth = new Element("Fourth");

            Queue queue = new Queue();

            Console.WriteLine("Is any elements in queue?: " + queue.IsAnyElement().ToString());

            queue.Add(first);
            queue.Add(second);
            queue.Add(third);
            queue.Add(fourth);
            queue.Get();
            queue.GetRemove();
            queue.Get();
            queue.Remove();
            queue.Get();
            queue.Remove();
            queue.Remove();

            Console.WriteLine("Is any elements in queue?: " + queue.IsAnyElement().ToString());
            Console.Read();
        }
    }
}
