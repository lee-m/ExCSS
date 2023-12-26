using ExCSS.New.Values;

namespace ExCSS
{
    internal sealed class AnimationDelayProperty : Property
    {
        //private static readonly IValueConverter
        //    ListConverter = Converters.TimeConverter.FromList().OrDefault(TimeValue.Zero);

        internal AnimationDelayProperty()
            : base(PropertyNames.AnimationDelay)
        {
        }
    }
}