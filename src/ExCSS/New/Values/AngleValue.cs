using System;
using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class AngleValue : BaseValue, IEquatable<AngleValue>, IComparable<AngleValue>, IFormattable
    {
        public AngleValue(IEnumerable<Token> parsedValue, float value, AngleUnit unit) : base(parsedValue)
        {
            Value = value;
            Type = unit;
        }

        public float Value { get; }
        public AngleUnit Type { get; }

        public string UnitString
        {
            get
            {
                switch (Type)
                {
                    case AngleUnit.Deg:
                        return UnitNames.Deg;

                    case AngleUnit.Grad:
                        return UnitNames.Grad;

                    case AngleUnit.Turn:
                        return UnitNames.Turn;

                    case AngleUnit.Rad:
                        return UnitNames.Rad;

                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        ///     Compares the magnitude of two angles.
        /// </summary>
        public static bool operator >=(AngleValue a, AngleValue b)
        {
            var result = a.CompareTo(b);
            return result == 0 || result == 1;
        }

        /// <summary>
        ///     Compares the magnitude of two angles.
        /// </summary>
        public static bool operator >(AngleValue a, AngleValue b)
            => a.CompareTo(b) == 1;

        /// <summary>
        ///     Compares the magnitude of two angles.
        /// </summary>
        public static bool operator <=(AngleValue a, AngleValue b)
        {
            var result = a.CompareTo(b);
            return result == 0 || result == -1;
        }

        /// <summary>
        ///     Compares the magnitude of two angles.
        /// </summary>
        public static bool operator <(AngleValue a, AngleValue b)
            => a.CompareTo(b) == -1;

        /// <summary>
        ///     Compares the current angle against the given one.
        /// </summary>
        /// <param name="other">The angle to compare to.</param>
        /// <returns>The result of the comparison.</returns>
        public int CompareTo(AngleValue other)
            => ToRadian().CompareTo(other.ToRadian());

        public static AngleUnit GetUnit(string s)
        {
            switch (s)
            {
                case "deg":
                    return AngleUnit.Deg;
                case "grad":
                    return AngleUnit.Grad;
                case "turn":
                    return AngleUnit.Turn;
                case "rad":
                    return AngleUnit.Rad;
                default:
                    return AngleUnit.None;
            }
        }

        public float ToRadian()
        {
            switch (Type)
            {
                case AngleUnit.Deg:
                    return (float)(Math.PI / 180.0 * Value);

                case AngleUnit.Grad:
                    return (float)(Math.PI / 200.0 * Value);

                case AngleUnit.Turn:
                    return (float)(2.0 * Math.PI * Value);

                default:
                    return Value;
            }
        }

        public float ToTurns()
        {
            switch (Type)
            {
                case AngleUnit.Deg:
                    return (float)(Value / 360.0);

                case AngleUnit.Grad:
                    return (float)(Value / 400.0);

                case AngleUnit.Rad:
                    return (float)(Value / (2.0 * Math.PI));

                default:
                    return Value;
            }
        }

        public bool Equals(AngleValue other)
            => ToRadian() == other.ToRadian();

        /// <summary>
        ///     Tests if another object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to test with.</param>
        /// <returns>True if the two objects are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            var other = obj as AngleValue;
            return other != null && Equals(other.Value);
        }

        /// <summary>
        ///     Returns a hash code that defines the current angle.
        /// </summary>
        /// <returns>The integer value of the hashcode.</returns>
        public override int GetHashCode()
            => (int)Value;

        public override ValueKind Kind => ValueKind.Angle;

        public override string ToString()
        {
            return string.Concat(Value.ToString(), UnitString);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Concat(Value.ToString(format, formatProvider), UnitString);
        }
    }
}