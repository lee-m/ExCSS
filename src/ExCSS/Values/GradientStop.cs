using ExCSS.New.Values;

namespace ExCSS
{
    public struct GradientStop
    {
        public GradientStop(ColorValue color, Length location)
        {
            Color = color;
            Location = location;
        }

        public ColorValue Color { get; }
        public Length Location { get; }
    }
}