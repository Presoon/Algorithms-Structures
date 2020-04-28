namespace Queue
{
    public class Element
    {
        private string value;
        private Element next;
        
        public Element(string value)
        {
            this.value = value;
        }

        ~Element() { }

        public Element GetNext()
        {
            return next;
        }

        public void SetNext(Element newElement)
        {
            next = newElement;
        }

        public string GetValue()
        {
            return value;
        }

    }
}