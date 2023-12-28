namespace ExCSS
{
    public readonly struct HashCode
    {
        private readonly int _hashCode;

        public HashCode(params object[] values)
        {
            unchecked
            {
                _hashCode = 17;

                foreach (var val in values)
                    _hashCode = _hashCode * 31 + val.GetHashCode();
            }
        }

        public override int GetHashCode()
            => _hashCode;
    }
}
