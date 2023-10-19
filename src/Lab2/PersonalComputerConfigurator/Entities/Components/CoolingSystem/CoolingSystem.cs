using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;

public class CoolingSystem : IClone<CoolingSystemBuilder>
{
    private Dimensions _dimensions;
    private IReadOnlyCollection<Socket> _supportiveSockets;
    private Tdp _maxTdp;

    public CoolingSystem(Dimensions dimensions, IReadOnlyCollection<Socket> supportiveSockets, Tdp maxTdp)
    {
        _dimensions = dimensions;
        _supportiveSockets = supportiveSockets;
        _maxTdp = maxTdp;
    }

    public bool IsCompatible(Cpu cpu)
    {
        if (cpu != null)
        {
            return _supportiveSockets.Any(supportiveSocket => cpu.Socket.Equals(supportiveSocket));
        }
        else
        {
            throw new NullObjectException();
        }
    }

    public bool CheckWarrantyObligations(Cpu cpu)
    {
            if (cpu != null && cpu.Tdp.Watt > _maxTdp.Watt)
            {
                return false;
            }
            else
            {
                return true;
            }
    }

    public CoolingSystemBuilder Clone()
    {
        var coolingSystemBuilder = new CoolingSystemBuilder();
        coolingSystemBuilder.WithMaxTdp(_maxTdp);
        coolingSystemBuilder.WithDimensions(_dimensions);
        coolingSystemBuilder.WithSupportiveSockets(_supportiveSockets);
        return coolingSystemBuilder;
    }
}