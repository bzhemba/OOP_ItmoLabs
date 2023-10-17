using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CoolingSystemCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;

public class CoolingSystemBuilder
{
    private Dimensions? _dimensions;
    private IReadOnlyCollection<Socket>? _supportiveSockets;
    private MaxTdp? _maxTdp;
    public CoolingSystemBuilder WithDimensions(Dimensions dimensions)
    {
        if (dimensions is { Length: > 0 } and { Height: > 0, Width: > 0 })
        {
            _dimensions = dimensions;
            return this;
        }

        throw new IncorrectFormatException($"Incorrect format of dimensions");
    }

    public CoolingSystemBuilder WithSupportiveSockets(IReadOnlyCollection<Socket> sockets)
    {
        _supportiveSockets = sockets;
        return this;
    }

    public CoolingSystemBuilder WithMaxTdp(MaxTdp maxTdp)
    {
        if (maxTdp is { Watt: > 0 })
        {
            _maxTdp = maxTdp;
            return this;
        }

        throw new IncorrectFormatException($"Incorrect format of dimensions");
    }

    public CoolingSystem Build()
    {
        if (_dimensions != null && _supportiveSockets != null && _maxTdp != null)
        {
            return new CoolingSystem(_dimensions, _supportiveSockets, _maxTdp);
        }
        else
        {
            throw new NullObjectException();
        }
    }
}