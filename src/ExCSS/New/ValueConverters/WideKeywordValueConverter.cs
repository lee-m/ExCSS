using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.ValueConverters
{
    internal sealed class WideKeywordValueConverter : EnumKeywordValueConverter<WideKeyword>
    {
        public WideKeywordValueConverter()
            : base(new KeyValuePair<string, WideKeyword>(Keywords.Initial, WideKeyword.Initial),
                   new KeyValuePair<string, WideKeyword>(Keywords.Inherit, WideKeyword.Inherit),
                   new KeyValuePair<string, WideKeyword>(Keywords.Unset, WideKeyword.Unset),
                   new KeyValuePair<string, WideKeyword>(Keywords.Revert, WideKeyword.Revert),
                   new KeyValuePair<string, WideKeyword>(Keywords.RevertLayer, WideKeyword.RevertLayer))
        { }
    }
}
