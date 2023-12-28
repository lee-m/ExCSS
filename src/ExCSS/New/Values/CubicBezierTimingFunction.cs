using System;
using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class CubicBezierTimingFunction : BaseValue, IEquatable<CubicBezierTimingFunction>
    {
        public static CubicBezierTimingFunction Ease(TokenValue parsedValue) => new(parsedValue, 0.25f, 0.1f, 0.25f, 1f);
        public static CubicBezierTimingFunction EaseIn(TokenValue parsedValue) => new(parsedValue, 0.42f, 0f, 1f, 1f);
        public static CubicBezierTimingFunction EaseOut(TokenValue parsedValue) => new(parsedValue, 0f, 0f, 0.58f, 1f);
        public static CubicBezierTimingFunction EaseInOut(TokenValue parsedValue) => new(parsedValue, 0.42f, 0f, 0.58f, 1f);
        public static CubicBezierTimingFunction Linear(TokenValue parsedValue) => new(parsedValue, 0f, 0f, 1f, 1f);

        public CubicBezierTimingFunction(TokenValue parsedValue, float x1, float y1, float x2, float y2) : base(parsedValue)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public float X1 { get; }
        public float Y1 { get; }
        public float X2 { get; }
        public float Y2 { get; }

        public override ValueKind Kind => ValueKind.CubicBezierTimingFunction;

        public bool Equals(CubicBezierTimingFunction other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return X1.Equals(other.X1)
                   && Y1.Equals(other.Y1)
                   && X2.Equals(other.X2)
                   && Y2.Equals(other.Y2);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) 
                || (obj is CubicBezierTimingFunction other && Equals(other));
        }

        public override int GetHashCode()
            => new HashCode(X1, Y1, X2, Y2).GetHashCode();
    }
}