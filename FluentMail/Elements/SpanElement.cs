namespace FluentMail.Elements
{
    public class SpanElement : HtmlElement
    {
        public SpanElement() : base("span")
        {
        }

        public SpanElement Style(string style)
        {
            Attribute("style", style);
            return this;
        }

        public SpanElement Text(string text)
        {
            AppendChild(new TextElement(text));
            return this;
        }
    }
}
