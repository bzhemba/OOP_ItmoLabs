using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;

public class Ram : IRamBuilderDirector
{
    private MemorySize _memorySize;
    private FormFactor _formFactor;
    private Xmp _profile;
    private DdrVersion _ddrVersion;
    private PowerConsumption _powerConsumption;
    private IList<FrequencyVoltagePair> _supportiveFrequencyVoltagePairs;

    public Ram(
        MemorySize memorySize,
        FormFactor formFactor,
        Xmp profile,
        DdrVersion ddrVersion,
        PowerConsumption powerConsumption,
        IList<FrequencyVoltagePair> supportiveFrequencyVoltagePairs)
    {
        _memorySize = memorySize;
        _formFactor = formFactor;
        _profile = profile;
        _ddrVersion = ddrVersion;
        _powerConsumption = powerConsumption;
        _supportiveFrequencyVoltagePairs = supportiveFrequencyVoltagePairs;
    }

    public IList<FrequencyVoltagePair> SupportiveFrequencyVoltagePairs =>
        _supportiveFrequencyVoltagePairs;

    public void ApplyXmpModifications(int index)
    {
        _supportiveFrequencyVoltagePairs[index] = new FrequencyVoltagePair(_profile.Frequency.Mhz, _profile.Voltage.V);
    }

    public IRamBuilder Direct(IRamBuilder builder)
    {
        if (builder != null)
        {
            builder.WithPowerConsumption(_powerConsumption);
            builder.WithXmp(_profile);
            builder.WithDdrVersion(_ddrVersion);
            builder.WithFormFactor(_formFactor);
            builder.WithMemorySize(_memorySize);
            builder.WithSupportiveFrequencyVoltagePairs(_supportiveFrequencyVoltagePairs);
            return builder;
        }
        else
        {
            throw new NullObjectException("Builder is empty");
        }
    }
}