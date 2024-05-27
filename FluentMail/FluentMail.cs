using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentMail
{
    public class FluentMail
    {
        private readonly HtmlElement _htmlElement;

        private FluentMail()
        {
            _htmlElement = new HtmlElement("html");
        }

        public static FluentMail Create()
        {
            return new FluentMail();
        }

        public FluentMail Html(Action<HtmlElement> config)
        {
            config(_htmlElement);
            return this;
        }

        public FluentMail Head(Action<HeadElement> config)
        {
            var headElement = new HeadElement();
            config(headElement);
            _htmlElement.AppendChild(headElement);
            return this;
        }

        public FluentMail Body(Action<BodyElement> config)
        {
            var bodyElement = new BodyElement();
            config(bodyElement);
            _htmlElement.AppendChild(bodyElement);
            return this;
        }

        public string Render()
        {
            return _htmlElement.Render();
        }
    }

    public class BodyElement : HtmlElement
    {
        public BodyElement() : base("body")
        {
        }

        public BodyElement Style(string style)
        {
            Attribute("style", style);
            return this;
        }

        public BodyElement Text(string text)
        {
            AppendChild(new TextElement(text));
            return this;
        }

        public BodyElement H1(string text, string style = null)
        {
            var headingElement = new HeadingElement("h1");
            headingElement.Text(text);
            if (style != null)
            {
                headingElement.Style(style);
            }
            AppendChild(headingElement);
            return this;
        }

        public BodyElement H1(Action<HeadingElement> config)
        {
            var headingElement = new HeadingElement("h1");
            config(headingElement);
            AppendChild(headingElement);
            return this;
        }

        public BodyElement H2(string text, string style = null)
        {
            var headingElement = new HeadingElement("h2");
            headingElement.Text(text);
            if (style != null)
            {
                headingElement.Style(style);
            }
            AppendChild(headingElement);
            return this;
        }

        public BodyElement H2(Action<HeadingElement> config)
        {
            var headingElement = new HeadingElement("h2");
            config(headingElement);
            AppendChild(headingElement);
            return this;
        }

        public BodyElement H3(string text, string style = null)
        {
            var headingElement = new HeadingElement("h3");
            headingElement.Text(text);
            if (style != null)
            {
                headingElement.Style(style);
            }
            AppendChild(headingElement);
            return this;
        }

        public BodyElement H3(Action<HeadingElement> config)
        {
            var headingElement = new HeadingElement("h3");
            config(headingElement);
            AppendChild(headingElement);
            return this;
        }

        public BodyElement H4(string text, string style = null)
        {
            var headingElement = new HeadingElement("h4");
            headingElement.Text(text);
            if (style != null)
            {
                headingElement.Style(style);
            }
            AppendChild(headingElement);
            return this;
        }

        public BodyElement H4(Action<HeadingElement> config)
        {
            var headingElement = new HeadingElement("h4");
            config(headingElement);
            AppendChild(headingElement);
            return this;
        }

        public BodyElement H5(string text, string style = null)
        {
            var headingElement = new HeadingElement("h5");
            headingElement.Text(text);
            if (style != null)
            {
                headingElement.Style(style);
            }
            AppendChild(headingElement);
            return this;
        }

        public BodyElement H5(Action<HeadingElement> config)
        {
            var headingElement = new HeadingElement("h5");
            config(headingElement);
            AppendChild(headingElement);
            return this;
        }

        public BodyElement H6(string text, string style = null)
        {
            var headingElement = new HeadingElement("h6");
            headingElement.Text(text);
            if (style != null)
            {
                headingElement.Style(style);
            }
            AppendChild(headingElement);
            return this;
        }

        public BodyElement H6(Action<HeadingElement> config)
        {
            var headingElement = new HeadingElement("h6");
            config(headingElement);
            AppendChild(headingElement);
            return this;
        }

        public BodyElement P(Action<HtmlElement> config)
        {
            var paragraphElement = new HtmlElement("p");
            config(paragraphElement);
            AppendChild(paragraphElement);
            return this;
        }

        public BodyElement Span(Action<SpanElement> config)
        {
            var spanElement = new SpanElement();
            config(spanElement);
            AppendChild(spanElement);
            return this;
        }

        public BodyElement Span(string text, string style = null)
        {
            var headingElement = new HeadingElement("span");
            headingElement.Text(text);
            if (style != null)
            {
                headingElement.Style(style);
            }
            AppendChild(headingElement);
            return this;
        }
    }

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

    public class TextElement : HtmlElement
    {
        private readonly string _text;

        public TextElement(string text) : base(null)
        {
            _text = text;
        }

        public override string Render()
        {
            return _text;
        }
    }

}
