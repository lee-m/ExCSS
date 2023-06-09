using System.Collections.Generic;

using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class WideKeywordValueConverter : IValueConverter2
    {
        public IValue Convert(IEnumerable<Token> value)
        {
            var keyword = value.OnlyOrDefault();

            if (keyword == null)
                return null;

            if(keyword.Data.Isi(Keywords.Initial)
               || keyword.Data.Isi(Keywords.Inherit)
               || keyword.Data.Isi(Keywords.Unset)
               || keyword.Data.Isi(Keywords.Revert)
               || keyword.Data.Isi(Keywords.RevertLayer))
            {
                return new KeywordValue(value, keyword.Data);
            }

            return null;
        }
    }
}
