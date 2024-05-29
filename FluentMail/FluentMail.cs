using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using FluentMail.Elements;

namespace FluentMail
{
    public class FluentMail
    {
        private string lang;
        private string headContent;
        private string bodyContent;

        public FluentMail Html(Action<HtmlConfig> htmlConfig)
        {
            var config = new HtmlConfig();
            htmlConfig(config);
            this.lang = config.Languague;
            return this;
        }

        public FluentMail Head(Action<HeadBuilder> headConfig)
        {
            var headBuilder = new HeadBuilder();
            headConfig(headBuilder);
            this.headContent = headBuilder.Build();
            return this;
        }

        public FluentMail Body(Action<BodyBuilder> bodyConfig)
        {
            var bodyBuilder = new BodyBuilder();
            bodyConfig(bodyBuilder);
            this.bodyContent = bodyBuilder.Build();
            return this;
        }

        public string Build()
        {
            return $@"
                <!DOCTYPE html>
                <html lang=""{lang}"">
                <head>
                    {headContent}
                </head>
                <body>
                    {bodyContent}
                </body>
                </html>";
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
            this.metas.Add($@"<meta name=""{name}"" content=""{content}"">");
            return this;
        }

        public HeadBuilder Meta(string charset)
        {
            this.metas.Add($@"<meta charset=""{charset}"">");
            return this;
        }

        public string Build()
        {
            var metaTags = string.Join("\n    ", metas);
            return $@"<title>{title}</title>{metaTags}";
        }
    }

    public class BodyBuilder
    {
        private List<string> rows = new List<string>();

        public BodyBuilder Row(Action<RowBuilder> rowConfig)
        {
            var rowBuilder = new RowBuilder();
            rowConfig(rowBuilder);
            rows.Add(rowBuilder.Build());
            return this;
        }

        public string Build()
        {
            return string.Join("\n", rows);
        }
    }


    public class RowBuilder
    {
        private string backgroundColor;
        private string style;
        private List<ColumnBuilder> columns = new List<ColumnBuilder>();

        public RowBuilder BackgroundColor(string color)
        {
            this.backgroundColor = color;
            return this;
        }

        public RowBuilder Style(string style)
        {
            this.style = style;
            return this;
        }

        public RowBuilder AddStyle(string style)
        {
            this.style += style;
            return this;
        }

        public RowBuilder Column(Action<ColumnBuilder> columnConfig)
        {
            var columnBuilder = new ColumnBuilder();
            columnConfig(columnBuilder);
            columns.Add(columnBuilder);
            return this;
        }

        public string Build()
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

            var rowStyle = !string.IsNullOrEmpty(backgroundColor) ? $"background-color: {backgroundColor};" : "";
                        return $@"
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0"" style=""table-layout: fixed; border-collapse: collapse;"">
                <tr style=""{rowStyle} {style}"">
                    {string.Join("\n", columnHtml)}
                </tr>
            </table>";
            }
        }
    public class ColumnBuilder
    {
        private string backgroundColor;
        private string style;
        private string content = "";
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
            content += $@"<img src=""{url}"", alt=""{alt}"" style=""{style}""/>";
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
            content += $@"<h1 style=""{style}"">{text}</h1>";
            return this;
        }

        public ColumnBuilder Paragraph(string text, string style = "")
        {
            content += $@"<p style=""{style}"">{text}</p>";
            return this;
        }

        public ColumnBuilder Button(string text, string url, string style = "")
        {
            content += $@"<a href=""{url}"" style=""{style}"">{text}</a>";
            return this;
        }

        public ColumnBuilder Row(Action<RowBuilder> rowConfig)
        {
            var rowBuilder = new RowBuilder();
            rowConfig(rowBuilder);
            subRows.Add(rowBuilder.Build());
            return this;
        }

        public string Build()
        {
            var widthStyle = !string.IsNullOrEmpty(width) ? $"width: {width};" : "";
            var subRowsContent = string.Join("\n", subRows);
            return $@"
<td style=""background-color: {backgroundColor}; vertical-align: top; {widthStyle} {style}"">
    {content}
    {subRowsContent}
</td>";
        }
    }

}
