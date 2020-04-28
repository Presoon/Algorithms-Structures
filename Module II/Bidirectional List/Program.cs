using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidirectional_List
{
    class Program
    {
        private static void Main(string[] args)
        {
            Element first = new Element("First");
            Element second = new Element("Second");
            Element third = new Element("Third");
            Element fourth = new Element("Fourth");

            BiList biList = new BiList();
            biList.Add(first);
            biList.Add(second);
            biList.Add(third);
            biList.Add(fourth);
            Console.WriteLine(fourth.Previous.Value);
            Console.WriteLine(second.Previous.Value);

            biList.Get();
            biList.RemoveAt(0);
            biList.Get();
            biList.RemoveAt(1);
            biList.Get();
            biList.RemoveAt(0);
            biList.Get();
            Console.WriteLine("Is there any elements in list?: " + biList.Check().ToString());
            Console.Read();
        }
    }
}
