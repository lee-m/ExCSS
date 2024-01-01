using System.Collections.Generic;
using System.Linq;

using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class IdentifierValueConverter : IValueConverter2
    {
        public IValue Convert(TokenValue value)
        {
            var element = value.OnlyOrDefault();

            if (element != null && element.Type == TokenType.Ident)
                return new IdentifierValue(value);

            return null;
        }
    }

    internal sealed class IdentifierListValueConverter : ListValueConverter<IdentifierValue>
    {
        public IdentifierListValueConverter() : base(Converters.Identifier)
        { }

        protected override ListValue<IdentifierValue> CreateListValue(TokenValue parsedValue, IEnumerable<IValue> convertedValues)
            => new IdentifierListValue(parsedValue, convertedValues.Cast<IdentifierValue>().ToList());
    }
}
