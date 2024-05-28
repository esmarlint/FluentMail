namespace FluentMail
{
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
