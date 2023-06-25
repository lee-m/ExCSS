using System.Collections.Generic;

using ExCSS.New.Enumerations;
using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    public class ContentDistributionValueConverter : IValueConverter2
    {
        private readonly Dictionary<string, ContentDistributionKeyword> _keywordMapping;

        public ContentDistributionValueConverter()
        {
            _keywordMapping = new Dictionary<string, ContentDistributionKeyword>
            {
                { Keywords.SpaceBetween, ContentDistributionKeyword.SpaceBetween },
                { Keywords.SpaceAround, ContentDistributionKeyword.SpaceAround },
                { Keywords.SpaceEvenly, ContentDistributionKeyword.SpaceEvenly },
                { Keywords.Stretch, ContentDistributionKeyword.Stretch },
            };
        }

        public IValue Convert(TokenValue value)
        {
            var keyword = value.OnlyOrDefault();

            if (keyword != null && _keywordMapping.TryGetValue(keyword.Data, out var mappedKeyword))
                return new ContentDistributionValue(value, mappedKeyword);

            return null;
        }
    }
}
