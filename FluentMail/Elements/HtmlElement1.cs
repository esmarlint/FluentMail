using System.Text;

namespace FluentMail.Elements
{
    public class HtmlElement
    {
        protected readonly string TagName;
        protected readonly Dictionary<string, string> Attributes;
        protected readonly List<HtmlElement> Children;

        public HtmlElement(string tagName)
        {
            TagName = tagName;
            Attributes = new Dictionary<string, string>();
            Children = new List<HtmlElement>();
        }

        public virtual HtmlElement Attribute(string name, string value)
        {
            Attributes[name] = value;
            return this;
        }

        public HtmlElement Style(string style)
        {
            Attribute("style", style);
            return this;
        }

        public HtmlElement Lang(string lang)
        {
            Attribute("lang", lang);
            return this;
        }

        public virtual void AppendChild(HtmlElement child)
        {
            Children.Add(child);
        }

        public virtual string Render()
        {
            var builder = new StringBuilder();
            builder.Append($"<{TagName}");

            foreach (var attribute in Attributes)
            {
                builder.Append($" {attribute.Key}=\"{attribute.Value}\"");
            }

            if (IsVoidElement())
            {
                builder.Append(">");
            }
            else
            {
                builder.Append(">");

                foreach (var child in Children)
                {
                    builder.Append(child.Render());
                }

                builder.Append($"</{TagName}>");
            }

            return builder.ToString();
        }

        protected virtual bool IsVoidElement()
        {
            return TagName == "meta" || TagName == "br" || TagName == "hr" || TagName == "img" || TagName == "input" || TagName == "link";
        }
    }
}
