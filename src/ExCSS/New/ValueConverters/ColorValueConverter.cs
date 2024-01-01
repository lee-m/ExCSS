using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class ColorValueConverter : IValueConverter2
    {
        public IValue Convert(TokenValue value)
        {
            var element = value.OnlyOrDefault();

            if (element != null && element.Type == TokenType.Ident)
                return ColorValue.FromName(new TokenValue(value), element.Data);

            if (element != null && element.Type == TokenType.Color && !((ColorToken)element).IsValid)
            {
                return ColorValue.FromHex(new TokenValue(value), element.Data);
            }

            return null;
        }
    }
}
