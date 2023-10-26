using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Exceptions;

public class AlreadyMarkedException : Exception
{
    public AlreadyMarkedException(string message)
        : base(message)
    {
    }

    public AlreadyMarkedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public AlreadyMarkedException()
    {
    }
}