namespace ExCSS
{
    internal sealed class FloatProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.FloatingConverter.OrDefault(Floating.None);

        internal FloatProperty()
            : base(PropertyNames.Float)
        {
        }
    }
}