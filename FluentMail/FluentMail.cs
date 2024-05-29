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
    public class FluentMail
    {
        private string lang;
        private string headContent;
        private string bodyContent;

        public FluentMail Html(Action<HtmlConfig> html)
        {
            var config = new HtmlConfig();
            html(config);
            this.lang = config.Languague;
            return this;
        }

        public FluentMail Head(Action<HeadBuilder> head)
        {
            var headBuilder = new HeadBuilder();
            head(headBuilder);
            this.headContent = headBuilder.Build();
            return this;
        }

        public FluentMail Body(Action<BodyBuilder> body)
        {
            var bodyBuilder = new BodyBuilder();
            body(bodyBuilder);
            this.bodyContent = bodyBuilder.Build();
            return this;
        }

        public string Build()
        {
            var builder = new StringBuilder();
            builder.AppendFormat(@"
            <!DOCTYPE html>
            <html lang=""{0}"">
            <head>
                {1}
            </head>
            <body>
                {2}
            </body>
            </html>", lang, headContent, bodyContent);
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

    public class HeadBuilder
    {
        private string title;
        private List<string> metas = new List<string>();

        public HeadBuilder Title(string title)
        {
            this.title = title;
            return this;
        }

        public HeadBuilder Meta(string name, string content)
        {
            metas.Add($@"<meta name=""{name}"" content=""{content}"">");
            return this;
        }

        public HeadBuilder Meta(string charset)
        {
            metas.Add($@"<meta charset=""{charset}"">");
            return this;
        }

        public string Build()
        {
            var metaTags = string.Join("\n    ", metas);
            return $"<title>{title}</title>\n    {metaTags}";
        }
    }

    public class BodyBuilder
    {
        private readonly StringBuilder rowsBuilder = new StringBuilder();

        public BodyBuilder Row(Action<RowBuilder> row)
        {
            var rowBuilder = new RowBuilder();
            row(rowBuilder);
            rowsBuilder.Append(rowBuilder.Build());
            return this;
        }

        public string Build()
        {
            return rowsBuilder.ToString();
        }
    }

    public class RowBuilder
    {
        private readonly StringBuilder columnsBuilder = new StringBuilder();

        public RowBuilder Column(Action<ColumnBuilder> column)
        {
            var columnBuilder = new ColumnBuilder();
            column(columnBuilder);
            columnsBuilder.Append(columnBuilder.Build());
            return this;
        }

        public string Build()
        {
            return $"<tr>{columnsBuilder}</tr>";
        }
    }

    public class ColumnBuilder
    {
        private readonly StringBuilder contentBuilder = new StringBuilder();

        public ColumnBuilder Image(string url, string alt = "", string style = "")
        {
            contentBuilder.AppendFormat(@"<img src=""{0}"" alt=""{1}"" style=""{2}""/>", url, alt, style);
            return this;
        }

        public ColumnBuilder H1(string text, string style = "")
        {
            contentBuilder.AppendFormat(@"<h1 style=""{0}"">{1}</h1>", style, text);
            return this;
        }

        public ColumnBuilder Paragraph(string text, string style = "")
        {
            contentBuilder.AppendFormat(@"<p style=""{0}"">{1}</p>", style, text);
            return this;
        }

        public ColumnBuilder Button(string text, string url, string style = "")
        {
            contentBuilder.AppendFormat(@"<a href=""{0}"" style=""{1}"">{2}</a>", url, style, text);
            return this;
        }

        public string Build()
        {
            string backgroundColor = "white";
            string widthStyle = "width:100%";
            string style = "";
            string subRowsContent = "";

            var builder = new StringBuilder();
            builder.AppendFormat(@"
                <td style=""background-color: {0}; vertical-align: top; {1} {2}"">
                    {3}
                    {4}
                </td>", backgroundColor, widthStyle, style, contentBuilder.ToString(), subRowsContent);

            return builder.ToString();
        }
    }

}
