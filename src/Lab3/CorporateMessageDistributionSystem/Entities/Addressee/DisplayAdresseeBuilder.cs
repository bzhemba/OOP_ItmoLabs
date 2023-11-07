using System;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.DisplayIntegration;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateMessageDistributionSystem.Entities.Addressee;

public class DisplayAdresseeBuilder : IAdresseeBuilder, IAdresseeProxyBuilder
{
    private IAdressee? _adressee;
    public IAdresseeProxyBuilder WithDisplay(Display display)
    {
        _adressee = new DisplayAdressee(display);
        return this;
    }

    public IAdresseeBuilder WithLogger(ILogger logger)
    {
        if (_adressee != null) _adressee = new AdresseeLogger(_adressee, logger);
        return this;
    }

    public IAdresseeBuilder WithPriority(Priority levelPriority)
    {
        if (_adressee != null) _adressee = new AdresseeProxy(_adressee, levelPriority);
        return this;
    }

    public IAdressee Build()
    {
        if (_adressee == null)
        {
            throw new ArgumentException("Addresse doesn't exist");
        }

        return _adressee;
    }
}