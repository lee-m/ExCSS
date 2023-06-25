using System.Collections.Generic;

using ExCSS.New.Enumerations;
using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class WideKeywordValueConverter : IValueConverter2
    {
        private readonly Dictionary<string, WideKeyword> _mapping;

        public WideKeywordValueConverter()
        {
            _mapping = new Dictionary<string, WideKeyword>
            {
                { Keywords.Initial, WideKeyword.Initial },
                { Keywords.Inherit, WideKeyword.Inherit },
                { Keywords.Unset, WideKeyword.Unset },
                { Keywords.Revert, WideKeyword.Revert },
                { Keywords.RevertLayer, WideKeyword.RevertLayer }
            };
        }

        public IValue Convert(TokenValue value)
        {
            var keyword = value.OnlyOrDefault();

            if (keyword == null)
                return null;

            if(_mapping.TryGetValue(keyword.Data, out var mappedKeyword))
                return new WideKeywordValue(value, mappedKeyword);

            return null;
        }
    }
}
