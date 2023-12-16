namespace AtmSystem.Application.Models.BankAccounts;

public class BankAccount
{
    public BankAccount(long id, long ownerId, int pinCode, int balance)
    {
        Id = id;
        OwnerId = ownerId;
        PinCode = pinCode;
        Balance = balance;
    }

    public long Id { get; }
    public long OwnerId { get; }
    public int PinCode { get; }
    public int Balance { get; private set; }

    public void UpdateBalance(int newBalance)
    {
        Balance = newBalance;
    }
}