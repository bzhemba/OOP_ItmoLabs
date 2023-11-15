using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.FileTreeVisualizerDecorator;

public class DirectoryIndentSymbolDecorator : EditOfTreeBase
{
    private string _directoryIndentSymbol;
    public DirectoryIndentSymbolDecorator(string directoryIndentSymbol, EditOfTreeBase? editOfTreeBase = null)
        : base(editOfTreeBase)
    {
        _directoryIndentSymbol = directoryIndentSymbol;
    }

    public override FileTreeVisualizer? GetTreeWithParametrizedSymbols(FileTreeVisualizer? tree)
    {
        return base.GetTreeWithParametrizedSymbols(tree)?.SetDirectoryIndentSymbol(_directoryIndentSymbol);
    }
}