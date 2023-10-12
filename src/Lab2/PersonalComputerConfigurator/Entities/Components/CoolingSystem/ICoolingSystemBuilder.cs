using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CoolingSystemCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;

public interface ICoolingSystemBuilder
{
    ICoolingSystemBuilder WithDimensions(Dimensions dimensions);
    ICoolingSystemBuilder WithSupportiveSockets(IReadOnlyCollection<Socket> sockets);
    ICoolingSystemBuilder WithMaxTdp(MaxTdp maxTdp);
    CoolingSystem Build();
}