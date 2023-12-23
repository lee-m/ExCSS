namespace ExCSS
{
    internal sealed class UnicodeBidirectionalProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.UnicodeModeConverter.OrDefault(UnicodeMode.Normal);

        internal UnicodeBidirectionalProperty()
            : base(PropertyNames.UnicodeBidirectional)
        {
        }
    }
}