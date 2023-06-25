using ExCSS.New.Values;

namespace ExCSS
{
    public sealed class Shadow
    {
        public Shadow(bool inset, Length offsetX, Length offsetY, Length blurRadius, Length spreadRadius, ColorValue color)
        {
            IsInset = inset;
            OffsetX = offsetX;
            OffsetY = offsetY;
            BlurRadius = blurRadius;
            SpreadRadius = spreadRadius;
            Color = color;
        }

        public ColorValue Color { get; }
        public Length OffsetX { get; }
        public Length OffsetY { get; }
        public Length BlurRadius { get; }
        public Length SpreadRadius { get; }
        public bool IsInset { get; }
    }
}