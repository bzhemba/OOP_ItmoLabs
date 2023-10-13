using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;

public interface IRamBuilder
{
    IRamBuilder WithMemorySize(MemorySize memorySize);
    IRamBuilder WithFormFactor(FormFactor formFactor);
    IRamBuilder WithXmp(Xmp profile);
    IRamBuilder WithDdrVersion(DdrVersion ddrVersion);
    IRamBuilder WithPowerConsumption(PowerConsumption powerConsumption);
    IRamBuilder WithSupportiveFrequencyVoltagePairs(IList<FrequencyVoltagePair> supportiveFrequencyVoltagePairs);
    Ram Build();
}