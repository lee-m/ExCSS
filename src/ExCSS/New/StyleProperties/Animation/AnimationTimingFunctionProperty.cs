using ExCSS.New.ValueConverters;
using ExCSS.New.Values;

namespace ExCSS
{
    public sealed class AnimationTimingFunctionProperty : Property
    {
        internal AnimationTimingFunctionProperty()
            : base(PropertyNames.AnimationTimingFunction)
        { }

        protected override IValue CoerceValue(TokenValue newTokenValue)
        {
            return TryConvert<TimingFunctionValueConverter>(newTokenValue)
                ?? TryConvert<WideKeywordValueConverter>(newTokenValue);
        }
    }
}