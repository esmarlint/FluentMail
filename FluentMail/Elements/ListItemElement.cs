namespace FluentMail.Elements
{
    public class ListItemElement : HtmlElement
    {
        public ListItemElement() : base("li")
        {
        }

        public ListItemElement Text(string text)
        {
            AppendChild(new TextElement(text));
            return this;
        }
    }
}
