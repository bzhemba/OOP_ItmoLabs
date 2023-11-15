using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.FileTreeVisualizerDecorator;

public class LastIndentSymbolDecorator : EditOfTreeBase
{
    private string _lastIndentSymbol;
    public LastIndentSymbolDecorator(string lastIndentSymbol, EditOfTreeBase? editOfTreeBase = null)
        : base(editOfTreeBase)
    {
        _lastIndentSymbol = lastIndentSymbol;
    }

    public override FileTreeVisualizer? GetTreeWithParametrizedSymbols(FileTreeVisualizer? tree)
    {
        return base.GetTreeWithParametrizedSymbols(tree)?.SetDirectoryIndentSymbol(_lastIndentSymbol);
    }
}