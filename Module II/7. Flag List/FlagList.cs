using System;

namespace Flag_List
{
    public class FlagList
    {
        readonly Element Flag;
        Element First;

        public FlagList()
        {
            Flag = new Element("Flag");
            First = Flag;
        }

        public void Add(Element newEl)
        {

            if (!Check())
            {
                First = newEl;
                newEl.Next = Flag;
            }
            else
            {
                Element temp = First;
                while (temp.Next != Flag)
                {
                    temp = temp.Next;
                }
                temp.Next = newEl;
                newEl.Previous = temp;
                newEl.Next = Flag;
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
                while (previous.Next != Flag)
                {
                    if (i == nr)
                    {
                        if (next.Next != Flag)
                        {
                            previous.Next = next.Next;
                            next.Next.Previous = previous;
                        }
                        else previous.Next = Flag;
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
            while (temp != Flag)
            {
                Console.WriteLine("Name of element: " + temp.Value);
                temp = temp.Next;
            }
        }

        public bool Check()
        {
            return First != Flag;
        }

        public void GetRemove()
        {
            if (First == Flag) return;
            var temp = First.Next;
            Console.WriteLine("Removed element: ");
            Console.WriteLine("Name of element: " + First.Value);
            First = temp;
        }
    }
}