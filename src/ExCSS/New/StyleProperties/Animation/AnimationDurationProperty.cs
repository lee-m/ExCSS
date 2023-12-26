using ExCSS.New.ValueConverters;
using ExCSS.New.Values;

namespace ExCSS.New.StyleProperties.Animation
{
    public sealed class AnimationDurationProperty : Property
    {
        internal AnimationDurationProperty() : base(PropertyNames.AnimationDuration)
        { }

        protected override IValue CoerceValue(TokenValue newTokenValue)
        {
            return TryConvert<TimeValueConverter>(newTokenValue)
                ?? TryConvert<TimeListValueConverter>(newTokenValue)
                ?? TryConvert<WideKeywordValueConverter>(newTokenValue);
        }
    }
}