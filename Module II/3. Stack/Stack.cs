using System;

namespace Stack
{
    public class Stack
    {
        Element Begin;

        public void Add(Element newEl)
        {
            if (Begin != null)
            {
                newEl.SetNext(Begin);
            }
            Begin = newEl;
        }

        public void Remove()
        {
            var temp = Begin.GetNext();
            Begin = temp;
        }

        public bool Check()
        {
            return Begin != null;
        }

        public void Get()
        {
            Console.WriteLine("Elements: ");
            var temp = Begin;
            while (temp != null)
            {
                Console.WriteLine("Name of element: " + temp.GetValue());
                temp = temp.GetNext();
            }
        }

        public void GetRemove()
        {
            var temp = Begin.GetNext();
            Console.WriteLine("Removed element: ");
            Console.WriteLine("Name of element: " + Begin.GetValue());
            Begin = temp;
        }
    }
}