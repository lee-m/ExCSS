namespace ExCSS
{
    internal sealed class WordBreakProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.WordBreakConverter;

        public WordBreakProperty()
            : base(PropertyNames.WordBreak)
        {
        }
    }
}