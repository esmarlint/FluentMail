namespace FluentMail.Elements
{
    public class LinkElement : HtmlElement
    {
        public LinkElement() : base("a")
        {
        }

        public LinkElement Text(string text)
        {
            AppendChild(new TextElement(text));
            return this;
        }
    }
}
