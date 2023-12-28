using System;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class StepsTimingFunction : BaseValue, IEquatable<StepsTimingFunction>
    {
        public static StepsTimingFunction StepStart(TokenValue parsedValue) => new(parsedValue, 1, Keywords.Start);
        public static StepsTimingFunction StepEnd(TokenValue parsedValue) => new(parsedValue, 1, Keywords.End);

        public StepsTimingFunction(TokenValue parsedValue, int intervals, string stepPosition) : base(parsedValue)
        {
            Intervals = Math.Max(1, intervals);
            StepPosition = stepPosition;
        }

        public int Intervals { get; }
        public string StepPosition { get; }

        public override ValueKind Kind => ValueKind.StepsTimingFunction;

        public bool Equals(StepsTimingFunction other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Intervals == other.Intervals
                   && StepPosition == other.StepPosition;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj)
                   || (obj is StepsTimingFunction other && Equals(other));
        }

        public override int GetHashCode()
            => new HashCode(Intervals, StepPosition).GetHashCode();
    }
}