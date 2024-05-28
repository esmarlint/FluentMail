namespace FluentMail.Elements
{
    public class HeadingElement : HtmlElement
    {
        public HeadingElement(string tagName) : base(tagName)
        {
        }

        public HeadingElement Style(string style)
        {
            Attribute("style", style);
            return this;
        }

        public HeadingElement Text(string text)
        {
            AppendChild(new TextElement(text));
            return this;
        }

        public HeadingElement Span(Action<SpanElement> config)
        {
            var spanElement = new SpanElement();
            config(spanElement);
            AppendChild(spanElement);
            return this;
        }
    }
}
