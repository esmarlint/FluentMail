namespace FluentMail.Elements
{
    public class ListElement : HtmlElement
    {
        public ListElement(string tagName) : base(tagName)
        {
        }

        public ListElement Li(string text, string? style = null)
        {
            var listItemElement = new ListItemElement();
            listItemElement.Text(text);
            if (style != null)
            {
                listItemElement.Style(style);
            }
            AppendChild(listItemElement);
            return this;
        }
    }
}
