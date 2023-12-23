namespace ExCSS
{
    internal sealed class TableLayoutProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.TableLayoutConverter.OrDefault(false);

        internal TableLayoutProperty()
            : base(PropertyNames.TableLayout)
        {
        }
    }
}