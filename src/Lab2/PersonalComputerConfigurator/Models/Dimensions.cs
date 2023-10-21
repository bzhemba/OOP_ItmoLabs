using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

public record Dimensions
{
    public Dimensions(int height, int width, int length)
    {
        if (height <= 0 || width <= 0 || length <= 0)
        {
            throw new IncorrectFormatException($"Incorrect format of dimensions");
        }

        Height = height;
        Width = width;
        Length = length;
    }

    public int Width { get; }

    public int Length { get; }

    public int Height { get; }
}