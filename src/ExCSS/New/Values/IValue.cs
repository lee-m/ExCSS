﻿namespace ExCSS.New.Values
{
    public interface IValue
    {
        ValueKind Kind { get; }
        string Original { get; }
    }
}
