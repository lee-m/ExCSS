﻿using System;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public class TimeValue : BaseValue, IEquatable<TimeValue>, IComparable<TimeValue>, IFormattable
    {
        public static readonly TimeValue Zero = new(TokenValue.Empty, 0f, TimeUnit.Ms);

        public TimeValue(TokenValue parsedValue, float value, TimeUnit unit)
            : base(parsedValue)
        {
            Value = value;
            Type = unit;
        }

        public float Value { get; }
        public TimeUnit Type { get; }
        public override ValueKind Kind => ValueKind.Time;

        public string UnitString
        {
            get
            {
                return Type switch
                {
                    TimeUnit.Ms => UnitNames.Ms,
                    TimeUnit.S => UnitNames.S,
                    _ => string.Empty
                };
            }
        }

        /// <summary>
        ///     Compares the magnitude of two times.
        /// </summary>
        public static bool operator >=(TimeValue a, TimeValue b)
        {
            var result = a.CompareTo(b);
            return result == 0 || result == 1;
        }

        /// <summary>
        ///     Compares the magnitude of two times.
        /// </summary>
        public static bool operator >(TimeValue a, TimeValue b)
        {
            return a.CompareTo(b) == 1;
        }

        /// <summary>
        ///     Compares the magnitude of two times.
        /// </summary>
        public static bool operator <=(TimeValue a, TimeValue b)
        {
            var result = a.CompareTo(b);
            return result == 0 || result == -1;
        }

        /// <summary>
        ///     Compares the magnitude of two times.
        /// </summary>
        public static bool operator <(TimeValue a, TimeValue b)
        {
            return a.CompareTo(b) == -1;
        }

        public int CompareTo(TimeValue other)
        {
            return ToMilliseconds().CompareTo(other.ToMilliseconds());
        }

        public static TimeUnit GetUnit(string s)
        {
            switch (s)
            {
                case "s":
                    return TimeUnit.S;
                case "ms":
                    return TimeUnit.Ms;
                default:
                    return TimeUnit.None;
            }
        }

        public float ToMilliseconds()
        {
            return Type == TimeUnit.S ? Value * 1000f : Value;
        }

        public bool Equals(TimeValue other)
        {
            return ToMilliseconds() == other.ToMilliseconds();
        }

        /// <summary>
        ///     Checks for equality of two times.
        /// </summary>
        public static bool operator ==(TimeValue a, TimeValue b)
        {
            return a.Equals(b);
        }

        /// <summary>
        ///     Checks for inequality of two times.
        /// </summary>
        public static bool operator !=(TimeValue a, TimeValue b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        ///     Tests if another object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to test with.</param>
        /// <returns>True if the two objects are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is TimeValue other) 
                return Equals(other);

            return false;
        }

        /// <summary>
        ///     Returns a hash code that defines the current time.
        /// </summary>
        /// <returns>The integer value of the hashcode.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        ///     Returns a string representing the time.
        /// </summary>
        /// <returns>The unit string.</returns>
        public override string ToString()
        {
            return string.Concat(Value.ToString(), UnitString);
        }

        /// <summary>
        ///     Returns a formatted string representing the time.
        /// </summary>
        /// <param name="format">The format of the number.</param>
        /// <param name="formatProvider">The provider to use.</param>
        /// <returns>The unit string.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Concat(Value.ToString(format, formatProvider), UnitString);
        }
    }
}