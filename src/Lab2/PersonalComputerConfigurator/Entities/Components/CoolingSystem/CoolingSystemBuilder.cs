using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;

public class CoolingSystemBuilder
{
    private Dimensions? _dimensions;
    private IReadOnlyCollection<Socket>? _supportiveSockets;
    private Tdp? _maxTdp;
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

    public CoolingSystemBuilder WithMaxTdp(Tdp maxTdp)
    {
            _maxTdp = maxTdp;
            return this;
    }

    public Cooler Build()
    {
            return new Cooler(
                _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)),
                _supportiveSockets ?? throw new ArgumentNullException(nameof(_supportiveSockets)),
                _maxTdp ?? throw new ArgumentNullException(nameof(_maxTdp)));
    }
}