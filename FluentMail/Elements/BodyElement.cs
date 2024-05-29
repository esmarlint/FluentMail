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

        public BodyElement Row(Action<RowElement> config)
        {
            var rowElement = new RowElement();
            config(rowElement);
            AppendChild(rowElement);
            return this;
        }
    }
    public class RowElement : HtmlElement
    {
        public RowElement() : base("tr")
        {
        }

        public RowElement Column(Action<ColumnElement> config)
        {
            var columnElement = new ColumnElement();
            config(columnElement);
            AppendChild(columnElement);
            return this;
        }

        public override string Render()
        {
            return $"<tr>{base.Render()}</tr>";
        }
    }

    public class ColumnElement : HtmlElement
    {
        public ColumnElement() : base("td")
        {
        }

        public ColumnElement Width(int width)
        {
            Attribute("width", $"{width}%");
            return this;
        }

        public ColumnElement H1(string text, string? style = "")
        {
            var h1Element = new HtmlElement("h1");
            h1Element.Style(style);
            h1Element.AppendChild(new TextElement(text));
            AppendChild(h1Element);
            return this;
        }

        public ColumnElement BackgroundColor(string color)
        {
            Style($"background-color: {color};");
            return this;
        }

        // Métodos similares para H2, H3, H4, H5, H6 y Paragraph

        public ColumnElement Button(string text, string url)
        {
            var buttonContainer = new HtmlElement("p");
            buttonContainer.Style("text-align: center;");
            var buttonElement = new HtmlElement("a");
            buttonElement.Attribute("href", url);
            buttonElement.Style("display: inline-block; padding: 10px 20px; background-color: #007bff; color: #fff; text-decoration: none; border-radius: 4px;");
            buttonElement.AppendChild(new TextElement(text));
            buttonContainer.AppendChild(buttonElement);
            AppendChild(buttonContainer);
            return this;
        }

        public ColumnElement Paragraph(string text, string style = "")
        {
            var paragraphElement = new HtmlElement("p");
            paragraphElement.Style(style);
            paragraphElement.AppendChild(new TextElement(text));
            AppendChild(paragraphElement);
            return this;
        }

        public RowElement Row(Action<RowElement> config)
        {
            var tableElement = new HtmlElement("table");
            tableElement.Attribute("width", "100%");
            var rowElement = new RowElement();
            config(rowElement);
            tableElement.AppendChild(rowElement);
            AppendChild(tableElement);
            return rowElement;
        }
    }
    public enum TextAlign
    {
        Left,
        Center,
        Right
    }
}
