using System;
using System.Collections.Generic;
using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public class PercentValue : BaseValue, IEquatable<PercentValue>, IComparable<PercentValue>, IFormattable
    {
        public PercentValue(IEnumerable<Token> parsedValue, float value) : base(parsedValue)
        {
            Value = value;
        }

        /// <summary>
        ///     Gets a zero percent value.
        /// </summary>
        public static readonly PercentValue Zero = new(TokenValue.Empty, 0f);

        /// <summary>
        ///     Gets a fifty percent value.
        /// </summary>
        public static readonly PercentValue Fifty = new(TokenValue.Empty, 50f);

        /// <summary>
        ///     Gets a hundred percent value.
        /// </summary>
        public static readonly PercentValue Hundred = new(TokenValue.Empty, 100f);

        public float NormalizedValue 
            => Value * 0.01f;
    
        public override ValueKind Kind
            => ValueKind.Percent;

        public float Value { get; }

        /// <summary>
        ///     Compares the magnitude of two percents.
        /// </summary>
        public static bool operator >=(PercentValue a, PercentValue b)
            => a.Value >= b.Value;

        /// <summary>
        ///     Compares the magnitude of two percents.
        /// </summary>
        public static bool operator >(PercentValue a, PercentValue b)
            => a.Value > b.Value;

        /// <summary>
        ///     Compares the magnitude of two percents.
        /// </summary>
        public static bool operator <=(PercentValue a, PercentValue b)
            => a.Value <= b.Value;

        /// <summary>
        ///     Compares the magnitude of two percents.
        /// </summary>
        public static bool operator <(PercentValue a, PercentValue b)
            => a.Value < b.Value;

        /// <summary>
        ///     Compares the current percentage against the given one.
        /// </summary>
        /// <param name="other">The percentage to compare to.</param>
        /// <returns>The result of the comparison.</returns>
        public int CompareTo(PercentValue other)
            => Value.CompareTo(other.Value);

        /// <summary>
        ///     Checks if the given percent value is equal to the current one.
        /// </summary>
        /// <param name="other">The other percent value.</param>
        /// <returns>True if both have the same value.</returns>
        public bool Equals(PercentValue other)
            => Value == other.Value;

        /// <summary>
        ///     Tests if another object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to test with.</param>
        /// <returns>True if the two objects are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is PercentValue other) return Equals(other);

            return false;
        }

        public override int GetHashCode()
            => Value.GetHashCode();

        public override string ToString()
            => Value + "%";

        public string ToString(string format, IFormatProvider formatProvider)
            => Value.ToString(format, formatProvider) + "%";
    }
}