using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.FileTreeVisualizerDecorator;

public class FileSymbolDecorator : EditOfTreeBase
{
    private string _fileSymbol;
    public FileSymbolDecorator(string fileSymbol, EditOfTreeBase? editOfTreeBase = null)
        : base(editOfTreeBase)
    {
        _fileSymbol = fileSymbol;
    }

    public override FileTreeVisualizer? GetTreeWithParametrizedSymbols(FileTreeVisualizer? tree)
    {
        return base.GetTreeWithParametrizedSymbols(tree)?.SetFileSymbol(_fileSymbol);
    }
}