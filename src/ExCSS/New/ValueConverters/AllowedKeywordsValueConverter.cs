using System;
using System.Collections.Generic;
using System.Linq;

using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class AllowedKeywordsValueConverter : IValueConverter2
    {
        private readonly List<string> _allowedKeywords;

        public AllowedKeywordsValueConverter(params string[] allowedKeywords)
        {
            _allowedKeywords = allowedKeywords.ToList();
        }

        public IValue Convert(TokenValue value)
        {
            var keyword = value.OnlyOrDefault();

            if (keyword == null)
                return null;

            if (_allowedKeywords.Contains(keyword.Data, StringComparer.InvariantCultureIgnoreCase))
                return new KeywordValue(value, keyword.Data);

            return null;
        }
    }
}
