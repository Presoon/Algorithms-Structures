using System;

namespace Queue_With_Priority
{
    static class Program
    {
        private static void Main(string[] args)
        {
            Element first = new Element("First", 5);
            Element second = new Element("Second", 3);
            Element third = new Element("Third", 8);
            Element fourth = new Element("Fourth", 2);

            PriorityQueue priorityQueue = new PriorityQueue();

            priorityQueue.Add(first);
            priorityQueue.Add(second);
            priorityQueue.Add(third);
            priorityQueue.Add(fourth);
            priorityQueue.Get();
            priorityQueue.GetRemove();
            priorityQueue.Get();
            priorityQueue.Remove();
            priorityQueue.Get();
            priorityQueue.Remove();
            priorityQueue.Remove();

            Console.WriteLine("Is there any elements in queue?: " + priorityQueue.Check().ToString());
            Console.Read();
        }
    }
}
