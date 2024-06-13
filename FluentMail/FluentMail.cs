using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using FluentMail.Elements;

namespace FluentMail
{

    interface IHtmlElement{
        string Build();
    }

    public abstract class HtmlElement : IHtmlElement
    {
        public string style;
        public StringBuilder ContentBuilder { get; } = new StringBuilder();
        public string backgroundColor;
        public string padding;


        public abstract string Build();

        public override string ToString()
        {
            return Build();
        }

        public HtmlElement Style(string style)
        {
            style = style;
            return this;
        }

        public HtmlElement AddStyle(string style)
        {
            if (this.style == null)
                this.style = style;
            else
                this.style += style;
            return this;
        }

        public HtmlElement Padding(string padding)
        {
            this.padding = padding;
            return this;
        }

        public HtmlElement BackgroundColor(string color)
        {
            this.backgroundColor = color;
            return this;
        }

    }

    public class FluentMail
    {
        private string lang;
        private BodyBuilder bodyBuilder;
        private HeadBuilder headBuilder;

        public FluentMail Html(Action<HtmlConfig> html)
        {
            var config = new HtmlConfig();
            html(config);
            this.lang = config.Languague;
            return this;
        }

        public FluentMail Head(Action<HeadBuilder> head)
        {
            headBuilder = new HeadBuilder();
            head(headBuilder);
            return this;
        }

        public FluentMail Body(Action<BodyBuilder> body)
        {
            bodyBuilder = new BodyBuilder();
            body(bodyBuilder);
            return this;
        }

        public string Build()
        {
            var builder = new StringBuilder();
            builder.AppendLine($@"
            <!DOCTYPE html>
            <html lang=""{lang}"">
            <head>
                {headBuilder.ToString()}
            </head>
            <body>
                {bodyBuilder.Build()}
            </body>
            </html>");
            return builder.ToString();
        }
    }

    public class HtmlConfig
    {
        public string Languague { get; private set; }

        public HtmlConfig Lang(string lang)
        {
            this.Languague = lang;
            return this;
        }
    }

    public class HeadBuilder: HtmlElement
    {
        public string title;

        public HeadBuilder Title(string title)
        {
            this.title = title;
            return this;
        }

        public HeadBuilder Meta(string name, string content)
        {
            ContentBuilder.AppendLine($@"<meta name=""{name}"" content=""{content}"">");
            return this;
        }

        public HeadBuilder Meta(string charset)
        {
            ContentBuilder.AppendLine($@"<meta charset=""{charset}"">");
            return this;
        }

        public override string Build()
        {
            ContentBuilder.Insert(0, $@"<title>{title}</title>");
            return ContentBuilder.ToString();
        }
    }

    public class BodyBuilder: HtmlElement
    {
        public BodyBuilder Row(Action<RowBuilder> row)
        {
            var rowBuilder = new RowBuilder();
            row(rowBuilder);
            ContentBuilder.AppendLine(rowBuilder.Build());
            return this;
        }

        public override string Build()
        {
            return ContentBuilder.ToString();
        }
    }


    public class RowBuilder: HtmlElement
    {
        private List<ColumnBuilder> columns = new List<ColumnBuilder>();


        public RowBuilder Column(Action<ColumnBuilder> column)
        {
            var columnBuilder = new ColumnBuilder();
            column(columnBuilder);
            columns.Add(columnBuilder);
            return this;
        }

        public override string Build()
        {
            int specifiedWidthColumns = columns.Count(col => !string.IsNullOrEmpty(col.GetWidth()));
            int unspecifiedWidthColumns = columns.Count - specifiedWidthColumns;

            string autoWidth = unspecifiedWidthColumns > 0 ? $"{100 / unspecifiedWidthColumns}%" : "100%";

            var columnHtml = columns.Select(col =>
            {
                if (string.IsNullOrEmpty(col.GetWidth()))
                {
                    col.Width(autoWidth);
                }
                return col.Build();
            });

            var tableStyle = !string.IsNullOrEmpty(padding) ? $"padding: {padding};" : "";  // <-- Añadir esta línea
            tableStyle += !string.IsNullOrEmpty(style) ? style : "";  // <-- Modificar esta línea

            var rowStyle = !string.IsNullOrEmpty(backgroundColor) ? $"background-color: {backgroundColor};" : "";
            ContentBuilder.AppendLine($@"
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0"" style=""table-layout: fixed; border-collapse: collapse; {tableStyle}"">  // <-- Modificar esta línea
            <tr style=""{rowStyle}"">");
            ContentBuilder.AppendLine(string.Join("\n", columnHtml));
            ContentBuilder.AppendLine("</tr></table>");

            return ContentBuilder.ToString();
        }
    }

    public class ColumnBuilder: HtmlElement
    {
        private string backgroundColor;
        private string style;
        private string width;
        private List<string> subRows = new List<string>();

        public ColumnBuilder BackgroundColor(string color)
        {
            this.backgroundColor = color;
            return this;
        }

        public ColumnBuilder Style(string style)
        {
            this.style = style;
            return this;
        }

        public ColumnBuilder Image(string url, string alt = "", string style = "")
        {
            ContentBuilder.AppendLine($@"<img src=""{url}"" alt=""{alt}"" style=""{style}""/>");
            return this;
        }

        public ColumnBuilder Width(string width)
        {
            this.width = width;
            return this;
        }

        public string GetWidth()
        {
            return this.width;
        }

        public ColumnBuilder H1(string text, string style = "")
        {
            ContentBuilder.AppendLine($@"<h1 style=""{style}"">{text}</h1>");
            return this;
        }

        public ColumnBuilder H1(string text, string style = "")
        {
            ContentBuilder.AppendLine($@"<h1 style=""{style}"">{text}</h1>");
            return this;
        }

        public ColumnBuilder H2(string text, string style = "")
        {
            ContentBuilder.AppendLine($@"<h2 style=""{style}"">{text}</h2>");
            return this;
        }

        public ColumnBuilder H3(string text, string style = "")
        {
            ContentBuilder.AppendLine($@"<h3 style=""{style}"">{text}</h3>");
            return this;
        }

        public ColumnBuilder H4(string text, string style = "")
        {
            ContentBuilder.AppendLine($@"<h4 style=""{style}"">{text}</h4>");
            return this;
        }

        public ColumnBuilder H5(string text, string style = "")
        {
            ContentBuilder.AppendLine($@"<h5 style=""{style}"">{text}</h5>");
            return this;
        }

        public override string ToString()
        {
            return ContentBuilder.ToString();
        }

        public ColumnBuilder Paragraph(string text, string style = "")
        {
            ContentBuilder.AppendLine($@"<p style=""{style}"">{text}</p>");
            return this;
        }

        public ColumnBuilder Button(string text, string url, string style = "")
        {
            ContentBuilder.AppendLine($@"<a href=""{url}"" style=""{style}"">{text}</a>");
            return this;
        }

        public ColumnBuilder Row(Action<RowBuilder> row)
        {
            var rowBuilder = new RowBuilder();
            row(rowBuilder);
            subRows.Add(rowBuilder.Build());
            return this;
        }

        public override string Build()
        {
            var widthStyle = !string.IsNullOrEmpty(width) ? $"width: {width};" : "";
            var subRowsContent = string.Join("\n", subRows);
            var builder = new StringBuilder();
            builder.AppendLine($@"
                <td style=""background-color: {backgroundColor}; vertical-align: top; {widthStyle} {style}"">
                    {ContentBuilder.ToString()}
                    {subRowsContent}
                </td>");
            return builder.ToString();
        }
    }
}

