using System;

namespace Cyclical_List
{
    public class CycList
    {

        Element First;

        public void Add(Element newEl)
        {
            if (!Check())
            {
                First = newEl;
            }
            else
            {
                Element temp = First;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newEl;
                newEl.Previous = temp;
                First.Previous = newEl;
            }
        }

        public void RemoveAt(int nr)
        {
            if (nr == 0)
            {
                Element temp = First.Next;
                First = temp;
            }
            else
            {
                Element previous = First;
                Element next = First.Next;
                int i = 1;
                while (previous.Next != null)
                {
                    if (i == nr)
                    {
                        if (next.Next != null)
                        {
                            previous.Next = next.Next;
                            next.Next.Previous = previous;
                        }
                        else previous.Next = null;
                        break;
                    }
                    previous = previous.Next;
                    next = next.Next;
                    i++;
                }
            }
        }

        public void Get()
        {
            Console.WriteLine("Elements: ");
            var temp = First;
            while (temp != null)
            {
                Console.WriteLine("Name of element: " + temp.Value);
                temp = temp.Next;
            }
        }

        public bool Check()
        {
            return First != null;
        }

        public void GetRemove()
        {
            var temp = First.Next;
            Console.WriteLine("Removed element: ");
            Console.WriteLine("Name of element: " + First.Value);
            First = temp;
        }
    }
}