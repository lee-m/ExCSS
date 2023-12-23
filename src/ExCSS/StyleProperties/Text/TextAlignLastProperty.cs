namespace ExCSS
{
    internal sealed class TextAlignLastProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.TextAlignLastConverter;

        public TextAlignLastProperty()
            : base(PropertyNames.TextAlignLast)
        {
        }
    }
}