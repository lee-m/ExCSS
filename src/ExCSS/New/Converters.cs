using System.Collections.Generic;

using ExCSS.New.Enumerations;
using ExCSS.New.ValueConverters;

namespace ExCSS.New
{
    internal static class Converters
    {
        public static readonly IValueConverter2 Time = new TimeValueConverter();
        public static readonly IValueConverter2 TimeList = new TimeListValueConverter();
        public static readonly IValueConverter2 Float = new NumericValueConverter(ValueExtensions.ToSingle, NumberUnit.Float);
        public static readonly IValueConverter2 ZeroToInfiniteFloat = new BoundedNumericValueConverter(Float, 0, float.MaxValue);
        public static readonly IValueConverter2 Integer = new NumericValueConverter((t) => t.ToInteger(), NumberUnit.Integer);
        public static readonly IValueConverter2 Identifier = new IdentifierValueConverter();
        public static readonly IValueConverter2 IdentifierList = new IdentifierListValueConverter();
        public static readonly IValueConverter2 WideKeyword = new WideKeywordValueConverter();
        public static readonly IValueConverter2 Color = new ColorValueConverter();
        public static readonly IValueConverter2 ContentDistribution = new ContentDistributionValueConverter();
        public static readonly IValueConverter2 BaselinePosition = new BaselinePositionValueConverter();
        public static readonly IValueConverter2 ContentPosition = new ContentPositionValueConverter();
        public static readonly IValueConverter2 SelfPosition = new SelfPositionValueConverter();

        public static readonly IValueConverter2 TimingFunction = new TimingFunctionValueConverter();
        public static readonly IValueConverter2 ColorFunction = new ColorFunctionValueConverter();

        public static readonly IValueConverter2 AnimationFillModes
            = new EnumKeywordValueConverter<AnimationFillMode>(new KeyValuePair<string, AnimationFillMode>(Keywords.None, AnimationFillMode.None),
                                                               new KeyValuePair<string, AnimationFillMode>(Keywords.Backwards, AnimationFillMode.Backwards),
                                                               new KeyValuePair<string, AnimationFillMode>(Keywords.Both, AnimationFillMode.Both),
                                                               new KeyValuePair<string, AnimationFillMode>(Keywords.Forwards, AnimationFillMode.Forwards));
    };
}
