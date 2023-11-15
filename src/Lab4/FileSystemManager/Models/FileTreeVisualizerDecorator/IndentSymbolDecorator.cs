using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.FileTreeVisualizerDecorator;

public class IndentSymbolDecorator : EditOfTreeBase
{
    private string _indentSymbol;
    public IndentSymbolDecorator(string indentSymbol, EditOfTreeBase? editOfTreeBase = null)
        : base(editOfTreeBase)
    {
        _indentSymbol = indentSymbol;
    }

    public override FileTreeVisualizer? GetTreeWithParametrizedSymbols(FileTreeVisualizer? tree)
    {
        return base.GetTreeWithParametrizedSymbols(tree)?.SetIndentSymbol(_indentSymbol);
    }
}