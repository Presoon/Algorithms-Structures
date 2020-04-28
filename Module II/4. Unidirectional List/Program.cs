using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidirectional_List
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Element first = new Element("First");
            Element second = new Element("Second");
            Element third = new Element("Third");
            Element fourth = new Element("Fourth");

            UniList uniList = new UniList();
            uniList.Add(first);
            uniList.Add(second);
            uniList.Add(third);
            uniList.Add(fourth);
            uniList.Get();
            uniList.RemoveAt(0);
            uniList.Get();
            uniList.RemoveAt(1);
            uniList.Get();
            uniList.RemoveAt(0);
            uniList.Get();
            Console.WriteLine("Is there any elements in list?: " + uniList.Check().ToString());
            Console.Read();
        }
    }
}
