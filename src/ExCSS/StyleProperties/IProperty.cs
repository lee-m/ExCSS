using ExCSS.New;
using ExCSS.New.Values;

namespace ExCSS
{
    public interface IProperty : IStylesheetNode
    {
        string Name { get; }
        string ValueText { get; }
        string Original { get; }
        bool IsImportant { get; }

        IValue Value { get; }
    }
}