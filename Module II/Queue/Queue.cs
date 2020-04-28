using System;

namespace Queue
{
    public class Queue
    {
        private Element Last;
        private Element First;

        public void Add(Element newElement)
        {
            if (!IsAnyElement())
            {
                First = newElement;
                Last = newElement;
            }
            else
            {
                Last.SetNext(newElement);
                Last = newElement;
            }

        }

        public void Remove()
        {
            if (!IsAnyElement()) return;
            if (First == Last)
            {
                Last = null;
                First = null;
            }
            else
            {
                First = First.GetNext();
            }


        }
        public void Get()
        {
            Console.WriteLine("Elements: ");
            var temp = First;
            while (temp != null)
            {
                Console.WriteLine("name of element: " + temp.GetValue());
                temp = temp.GetNext();
            }
        }

        public bool IsAnyElement()
        {
            return First != null;
        }

        public void GetRemove()
        {
            var temp = First.GetNext();
            Console.WriteLine("Element removed: ");
            Console.WriteLine("Name of element: " + First.GetValue());
            First = temp;

        }
    }
}