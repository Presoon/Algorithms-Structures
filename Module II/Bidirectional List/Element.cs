namespace Bidirectional_List
{
    public class Element
    {
        public string Value { get; }

        public Element Next { get; set; }

        public Element Previous { get; set; }

        public Element(string value)
        {
            this.Value = value;

        }
    }
}