using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public interface IAdresseeBuilder
{
    public IAdresseeBuilder WithLogger(ILogger logger);

    public IAdresseeBuilder WithPriority(Priority levelPriority);
    public IAdressee Build();
}