using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CoolingSystemCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;

public class CoolingSystem : ICheckCompatibility, ICoolingSystemBuilderDirector
{
    private Dimensions _dimensions;
    private IReadOnlyCollection<Socket> _supportiveSockets;
    private MaxTdp _maxTdp;

    public CoolingSystem(Dimensions dimensions, IReadOnlyCollection<Socket> supportiveSockets, MaxTdp maxTdp)
    {
        _dimensions = dimensions;
        _supportiveSockets = supportiveSockets;
        _maxTdp = maxTdp;
    }

    public NotificationSystem IsCompatible(Cpu cpu)
    {
        if (cpu != null)
        {
            return _supportiveSockets.Any(supportiveSocket => cpu.Socket.Equals(supportiveSocket))
                ? NotificationSystem.Ok
                : NotificationSystem.IncompatibilityProblem;
        }
        else
        {
            throw new NullObjectException();
        }
    }

    public NotificationSystem CheckWarrantyObligations(Cpu cpu)
    {
        if (cpu != null)
        {
            if (cpu.Tdp.Watt > _maxTdp.Watt)
            {
                return NotificationSystem.DisclaimerOfWarrantyObligations;
            }
            else
            {
                return NotificationSystem.Ok;
            }
        }
        else
        {
            throw new NullObjectException();
        }
    }

    public ICoolingSystemBuilder Direct(ICoolingSystemBuilder coolingSystemBuilder)
    {
        if (coolingSystemBuilder != null)
        {
            coolingSystemBuilder.WithMaxTdp(_maxTdp);
            coolingSystemBuilder.WithDimensions(_dimensions);
            coolingSystemBuilder.WithSupportiveSockets(_supportiveSockets);
            return coolingSystemBuilder;
        }
        else
        {
            throw new NullObjectException("Builder is empty");
        }
    }
}