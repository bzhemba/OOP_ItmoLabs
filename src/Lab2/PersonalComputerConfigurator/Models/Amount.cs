using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

public record Amount
{
    public Amount(int piece)
    {
        if (piece < 0)
        {
            throw new IncorrectFormatException($"Incorrect format of amount");
        }

        Piece = piece;
    }

    public int Piece { get; }
}