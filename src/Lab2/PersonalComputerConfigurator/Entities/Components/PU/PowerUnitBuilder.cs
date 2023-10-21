using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.PowerUnitCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;

public class PowerUnitBuilder
{
    private PeakLoad? _peakLoad;
    public PowerUnitBuilder WithPeakload(PeakLoad peakLoad)
    {
            _peakLoad = peakLoad;
            return this;
    }

    public PowerUnit Build()
    {
            return new PowerUnit(_peakLoad ?? throw new ArgumentNullException(nameof(_peakLoad)));
    }
}