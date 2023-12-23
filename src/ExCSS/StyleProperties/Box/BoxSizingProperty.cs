namespace ExCSS
{
    internal class BoxSizingProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.BoxSizingConverter.OrDefault(Keywords.ContentBox);

        public BoxSizingProperty() 
            : base(PropertyNames.BoxSizing, PropertyFlags.None)
        { }
    }
}
