namespace ExCSS
{
    internal sealed class FontVariantProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.FontVariantConverter.OrDefault(FontVariant.Normal);

        internal FontVariantProperty()
            : base(PropertyNames.FontVariant, PropertyFlags.Inherited)
        {
        }
    }
}