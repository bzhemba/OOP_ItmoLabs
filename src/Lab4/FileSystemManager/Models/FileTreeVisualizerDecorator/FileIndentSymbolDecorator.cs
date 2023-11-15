using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.FileTreeVisualizerDecorator;

public class FileIndentSymbolDecorator : EditOfTreeBase
{
    private string _fileIndentSymbol;
    public FileIndentSymbolDecorator(string fileIndentSymbol, EditOfTreeBase? editOfTreeBase = null)
        : base(editOfTreeBase)
    {
        _fileIndentSymbol = fileIndentSymbol;
    }

    public override FileTreeVisualizer? GetTreeWithParametrizedSymbols(FileTreeVisualizer? tree)
    {
        return base.GetTreeWithParametrizedSymbols(tree)?.SetFileIndentSymbol(_fileIndentSymbol);
    }
}