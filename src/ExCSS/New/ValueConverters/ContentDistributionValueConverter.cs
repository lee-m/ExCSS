using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.ValueConverters
{
    internal sealed class ContentDistributionValueConverter : EnumKeywordValueConverter<ContentDistributionKeyword>
    {
        public ContentDistributionValueConverter()
            : base(new KeyValuePair<string, ContentDistributionKeyword>(Keywords.SpaceBetween, ContentDistributionKeyword.SpaceBetween),
                   new KeyValuePair<string, ContentDistributionKeyword>(Keywords.SpaceAround, ContentDistributionKeyword.SpaceAround),
                   new KeyValuePair<string, ContentDistributionKeyword>(Keywords.SpaceEvenly, ContentDistributionKeyword.SpaceEvenly),
                   new KeyValuePair<string, ContentDistributionKeyword>(Keywords.Stretch, ContentDistributionKeyword.Stretch))
        { }
    }
}
