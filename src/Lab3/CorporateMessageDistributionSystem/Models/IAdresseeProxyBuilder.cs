using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

public interface IAdresseeProxyBuilder
{
    public IAdresseeBuilder WithPriority(Priority levelPriority);
}