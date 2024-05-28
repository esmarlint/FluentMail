namespace FluentMail.Elements
{
    public class HeadElement : HtmlElement
    {
        public HeadElement() : base("head")
        {
        }

        public HeadElement Title(string title)
        {
            var titleElement = new HtmlElement("title");
            titleElement.AppendChild(new TextElement(title));
            AppendChild(titleElement);
            return this;
        }

        public HeadElement Meta(string name, string content)
        {
            var metaElement = new HtmlElement("meta");
            metaElement.Attribute(name, content);
            AppendChild(metaElement);
            return this;
        }
    }
}
