namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Services;

public abstract class Handler
{
    protected Handler? NextHandler { get; set; }

    public Handler SetNext(Handler handler)
    {
        NextHandler = handler;
        return handler;
    }

    public abstract void HandleRequest(string path, int level);
}