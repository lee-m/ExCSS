using System.Collections.Generic;

using ExCSS.New.ValueConverters;
using ExCSS.New.Values;

namespace ExCSS.New.StyleProperties.Animation
{
    public sealed class AnimationIterationCountProperty : Property
    {
        internal AnimationIterationCountProperty()
            : base(PropertyNames.AnimationIterationCount)
        { }

        internal override IEnumerable<IValueConverter2> GetValueConverters()
        {
            var infiniteKeywordConverter = new AllowedKeywordsValueConverter(Keywords.Infinite);

            return new[]
            {
                Converters.WideKeyword, 
                Converters.ZeroToInfiniteFloat,
                new CombiListValueConverter(infiniteKeywordConverter, Converters.ZeroToInfiniteFloat)
            };
        }
    }
}