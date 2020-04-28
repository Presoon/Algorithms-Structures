namespace Unidirectional_List
{
    public class Element
    {
        public string Value { get; set; }
        public Element Next { get; set; }

        public Element(string value)
        {
            this.Value = value;

        }
    }
}