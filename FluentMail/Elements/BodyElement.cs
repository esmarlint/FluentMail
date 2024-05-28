namespace FluentMail.Elements
{
    public class BodyElement : HtmlElement
    {
        public BodyElement() : base("body")
        {
        }

        public BodyElement Text(string text)
        {
            AppendChild(new TextElement(text));
            return this;
        }

        public BodyElement H1(string text, string? style = null)
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

        public BodyElement H2(string text, string? style = null)
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

        public BodyElement H3(string text, string? style = null)
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

        public BodyElement H4(string text, string? style = null)
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

        public BodyElement H5(string text, string? style = null)
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

        public BodyElement H6(string text, string? style = null)
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

        public BodyElement Span(string text, string? style = null)
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

        public BodyElement Img(string src, string? alt = null, string? style = null)
        {
            var imgElement = new ImageElement();
            imgElement.Attribute("src", src);
            if (alt != null)
            {
                imgElement.Attribute("alt", alt);
            }
            if (style != null)
            {
                imgElement.Style(style);
            }
            AppendChild(imgElement);
            return this;
        }

        public BodyElement A(string text, string href = "#", string? style = null)
        {
            var linkElement = new LinkElement();
            linkElement.Attribute("href", href);
            linkElement.Text(text);
            if (style != null)
            {
                linkElement.Style(style);
            }
            AppendChild(linkElement);
            return this;
        }

        public BodyElement Ol(Action<ListElement> config)
        {
            var listElement = new ListElement("ol");
            config(listElement);
            AppendChild(listElement);
            return this;
        }
    }
}
