using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flag_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Element first = new Element("First");
            Element second = new Element("Second");
            Element third = new Element("Third");
            Element fourth = new Element("Fourth");

            FlagList flagList = new FlagList();

            flagList.Add(first);
            flagList.Add(second);
            flagList.Add(third);
            flagList.Add(fourth);


            flagList.Get();
            flagList.RemoveAt(0);
            flagList.Get();
            flagList.RemoveAt(1);
            flagList.Get();
            flagList.RemoveAt(0);
            flagList.Get();

            Console.WriteLine("Is there any elements in list?: " + flagList.Check().ToString());
            Console.Read();
        }
    }
}
