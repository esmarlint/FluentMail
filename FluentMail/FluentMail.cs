using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMail.Elements;

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
}
