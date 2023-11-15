using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Models.FileTreeVisualizerDecorator;

public class EditOfTreeBase
{
    private readonly EditOfTreeBase? _tree;

    protected EditOfTreeBase(EditOfTreeBase? editOfTreeBase = null)
    {
        _tree = editOfTreeBase;
    }

    public virtual FileTreeVisualizer? GetTreeWithParametrizedSymbols(FileTreeVisualizer? tree)
    {
        if (_tree != null)
        {
            tree = _tree.GetTreeWithParametrizedSymbols(tree);
        }

        return tree;
    }
}