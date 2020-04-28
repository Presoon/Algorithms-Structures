namespace Queue_With_Priority
{

    public class Element
    {
        private string value;
        private int priority;
        private Element next;

        public Element(string value, int priority)
        {
            this.priority = priority;
            this.value = value;
        }

        ~Element() { }


        public Element GetNext()
        {
            return next;
        }

        public void SetNext(Element newEl)
        {
            next = newEl;
        }

        public string GetValue()
        {
            return value;
        }

        public int GetPriority()
        {
            return priority;
        }

    }
}