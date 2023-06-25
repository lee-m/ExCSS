using System;
using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public class NumberValue : BaseValue, IEquatable<NumberValue>, IComparable<NumberValue>, IFormattable
    {
        private readonly NumberUnit _unit;

        public NumberValue(IEnumerable<Token> parsedValue, float value, NumberUnit unit) : base(parsedValue)
        {
            Value = value;
            _unit = unit;
        }

        public float Value { get; }

        public bool IsInteger
            => _unit == NumberUnit.Integer;

        public override ValueKind Kind 
            => ValueKind.Number;

        public static bool operator >=(NumberValue a, NumberValue b) 
            => a.Value >= b.Value;

        public static bool operator >(NumberValue a, NumberValue b) 
            => a.Value > b.Value;

        public static bool operator <=(NumberValue a, NumberValue b)
            => a.Value <= b.Value;

        public static bool operator <(NumberValue a, NumberValue b)
            => a.Value < b.Value;

        public int CompareTo(NumberValue other)
            => Value.CompareTo(other.Value);

        public bool Equals(NumberValue other)
            => Value == other.Value && _unit == other._unit;

        public static bool operator ==(NumberValue a, NumberValue b)
            => a.Value == b.Value;

        public static bool operator !=(NumberValue a, NumberValue b)
            => a.Value != b.Value;

        public override bool Equals(object obj)
            => obj is NumberValue other && Equals(other);

        public override int GetHashCode()
            => Value.GetHashCode();

        public override string ToString()
            => Value.ToString();

        public string ToString(string format, IFormatProvider formatProvider)
            => Value.ToString(format, formatProvider);
    }
}