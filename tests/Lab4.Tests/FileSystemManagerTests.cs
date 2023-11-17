using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Entities.Command.CommandParser;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class FileSystemManagerTests
{
    [Fact]
    public void ParseConsoleTest()
    {
        var connectCommandParser = new ConnectLocalCommandParser();
        var disconnectCommandParser = new DisconnectCommandParser();
        var fileCopyCommandParser = new FileCopyCommandParser();
        var fileDeleteCommandParser = new FileDeleteCommandParser();
        var fileMoveCommandParser = new FileMoveCommandParser();
        var fileRenameCommandParser = new FileRenameCommandParser();
        var fileShowCommandParser = new FileShowConsoleCommandParser();
        var treeGoToCommandParser = new TreeGoToCommandParser();
        var treeListCommandParser = new TreeListCommandParser();
        connectCommandParser.SetNext(disconnectCommandParser)
            ?.SetNext(fileCopyCommandParser)
            ?.SetNext(fileDeleteCommandParser)
            ?.SetNext(fileMoveCommandParser)
            ?.SetNext(fileCopyCommandParser)
            ?.SetNext(fileRenameCommandParser)
            ?.SetNext(fileShowCommandParser)
            ?.SetNext(treeGoToCommandParser)
            ?.SetNext(treeListCommandParser);
        string command = "connect /Users/ -m local";
        ICommand? request = connectCommandParser.Parse(command);
        bool result = request is ConnectToLocalSystemCommand;
        Assert.True(result);
    }
}