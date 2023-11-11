using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManager.Exceptions.ConnectionExceptions;

public class ConnectionException : Exception
{
    public ConnectionException(string message)
        : base(message)
    {
    }

    public ConnectionException()
    {
    }

    public ConnectionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}