using System.Collections.Generic;

using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal abstract class EnumKeywordValueConverter<TEnum> : IValueConverter2 where TEnum: unmanaged
    {
        private readonly Dictionary<string, TEnum> _mapping;

        protected EnumKeywordValueConverter(params KeyValuePair<string, TEnum>[] mappingValues)
        {
            _mapping = new Dictionary<string, TEnum>();

            foreach (var pair in mappingValues)
                _mapping.Add(pair.Key, pair.Value);
        }

        public IValue Convert(TokenValue value)
        {
            var keyword = value.OnlyOrDefault();

            if (keyword == null)
                return null;

            if (_mapping.TryGetValue(keyword.Data, out var mappedKeyword))
                return new EnumKeywordValue<TEnum>(value, mappedKeyword);

            return null;
        }
    }
}
