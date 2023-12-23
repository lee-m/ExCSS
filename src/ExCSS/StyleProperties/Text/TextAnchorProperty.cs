namespace ExCSS
{
    internal sealed class TextAnchorProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.TextAnchorConverter;

        public TextAnchorProperty()
            : base(PropertyNames.TextAnchor)
        {
        }
    }
}