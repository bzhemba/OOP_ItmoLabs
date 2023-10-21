using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;

public class Cooler : IClone<CoolingSystemBuilder>
{
    private IReadOnlyCollection<Socket> _supportiveSockets;

    public Cooler(Dimensions dimensions, IReadOnlyCollection<Socket> supportiveSockets, Tdp maxTdp)
    {
        Dimensions = dimensions;
        _supportiveSockets = supportiveSockets;
        MaxTdp = maxTdp;
    }

    public Dimensions Dimensions { get; }
    public Tdp MaxTdp { get; }

    public bool IsCompatible(Cpu cpu)
    {
        if (cpu != null)
        {
            if (_supportiveSockets.Any(socket => socket.Name == cpu.Socket.Name))
            {
                return true;
            }

            {
                return false;
            }
        }

        return false;
    }

    public bool CheckWarrantyObligations(Cpu cpu)
    {
        return cpu == null || cpu.Tdp.Watt <= MaxTdp.Watt;
    }

    public CoolingSystemBuilder Clone()
    {
        var coolingSystemBuilder = new CoolingSystemBuilder();
        coolingSystemBuilder.WithMaxTdp(MaxTdp);
        coolingSystemBuilder.WithDimensions(Dimensions);
        coolingSystemBuilder.WithSupportiveSockets(_supportiveSockets);
        return coolingSystemBuilder;
    }

    public CoolingSystemBuilder Direct(CoolingSystemBuilder builder)
    {
        if (builder != null)
        {
            builder.WithDimensions(Dimensions).WithMaxTdp(MaxTdp).WithSupportiveSockets(_supportiveSockets).Build();
            return builder;
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }
    }
}
