﻿namespace ExCSS
{
    public enum TokenType : byte
    {
        String,
        Url,
        Color,
        Hash,
        Comment,
        AtKeyword,
        Ident,
        Function,
        Number,
        Percentage,
        Dimension,
        Range,
        Cdo,
        Cdc,
        Column,
        Delim,
        Match,
        RoundBracketOpen,
        RoundBracketClose,
        CurlyBracketOpen,
        CurlyBracketClose,
        SquareBracketOpen,
        SquareBracketClose,
        Colon,
        Comma,
        Semicolon,
        Whitespace,
        EndOfFile
    }
}