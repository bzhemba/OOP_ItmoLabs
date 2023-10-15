using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CoolingSystemCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;

public class CoolingSystemBuilder
{
    private Dimensions? _dimensions;
    private IReadOnlyCollection<Socket>? _supportiveSockets;
    private MaxTdp? _maxTdp;
    public CoolingSystemBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public CoolingSystemBuilder WithSupportiveSockets(IReadOnlyCollection<Socket> sockets)
    {
        _supportiveSockets = sockets;
        return this;
    }

    public CoolingSystemBuilder WithMaxTdp(MaxTdp maxTdp)
    {
        _maxTdp = maxTdp;
        return this;
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