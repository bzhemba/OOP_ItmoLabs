using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;

public record VideoCardDimensions
{
    public VideoCardDimensions(int width, int length)
    {
        if (width <= 0 || length <= 0)
        {
            throw new IncorrectFormatException($"Incorrect format of dimensions");
        }

        Width = width;
        Length = length;
    }

    public int Width { get; }

    public int Length { get; }
}
