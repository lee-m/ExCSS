using System.Collections.Generic;

using ExCSS.New.ValueConverters;

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
                Converters.ZeroToInfiniteFloat,
                infiniteKeywordConverter,
                new CombiListValueConverter(infiniteKeywordConverter, Converters.ZeroToInfiniteFloat)
            };
        }
    }
}