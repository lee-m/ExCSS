namespace ExCSS
{
    internal sealed class BackfaceVisibilityProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.BackfaceVisibilityConverter.OrDefault(true);

        internal BackfaceVisibilityProperty()
            : base(PropertyNames.BackfaceVisibility)
        {
        }
    }
}