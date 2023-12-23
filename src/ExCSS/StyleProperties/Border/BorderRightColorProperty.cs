using ExCSS.New.Values;

namespace ExCSS
{
    internal sealed class BorderRightColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.CurrentColorConverter.OrDefault(ColorValue.Transparent);

        internal BorderRightColorProperty()
            : base(PropertyNames.BorderRightColor)
        {
        }
    }
}