using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services.ChainOfResponsibilitiesTreePrinter;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

public class DirectoryTreePrinter
{
    private Handler _handler;

    public DirectoryTreePrinter()
    {
        _handler = new DirectoryHandler();
        _handler
            .SetNext(new FileHandler())
            .SetNext(new SymbolicLinkHandler());
    }

    public void PrintDirectoryTree(string path)
    {
        _handler.HandleRequest(path, 0);
    }
}