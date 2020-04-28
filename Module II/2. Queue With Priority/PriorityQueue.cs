using System;

namespace Queue_With_Priority
{
    public class PriorityQueue
    {
        private Element First;

        public void Add(Element newEl)
        {
            if (!Check())
            {
                First = newEl;
            }
            else
            {
                Priority(newEl, First);
            }
        }

        public void Remove()
        {
            if (!Check()) return;
            First = First.GetNext() ?? null;
        }

        public void Get()
        {
            Console.WriteLine("Elements: ");
            var temp = First;
            while (temp != null)
            {
                Console.WriteLine("Name of element: " + temp.GetValue());
                temp = temp.GetNext();
            }
        }

        public bool Check()
        {
            return First != null;
        }

        private void Priority(Element newEl, Element oldEl)
        {
            while (true)
            {
                if (newEl.GetPriority() > First.GetPriority())
                {
                    newEl.SetNext(First);
                    First = newEl;
                }
                else if (oldEl.GetNext() == null)
                {
                    oldEl.SetNext(newEl);
                }
                else if (newEl.GetPriority() > oldEl.GetNext().GetPriority())
                {
                    newEl.SetNext(oldEl.GetNext());
                    oldEl.SetNext(newEl);
                }
                else
                {
                    oldEl = oldEl.GetNext();
                    continue;
                }

                break;
            }
        }

        public void GetRemove()
        {
            Element temp;
            temp = First.GetNext();
            Console.WriteLine("Removed element: ");
            Console.WriteLine("Name of element: " + First.GetValue());
            First = temp;
        }

    }
}