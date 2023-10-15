namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Validator;

public abstract class Validator
{
    protected Approver successor;
    public void SetSuccessor(Approver successor)
    {
        this.successor = successor;
    }
    public abstract void ProcessRequest(Purchase purchase);
}