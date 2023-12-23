namespace ExCSS
{
    internal sealed class FlexProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = Converters.FlexConverter;

        internal FlexProperty()
            : base(PropertyNames.Flex)
        { }
    }
}
