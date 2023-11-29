namespace AtmSystem.Application.Models.BankAccounts;

public record BankAccount(long Id, long OwnerId, int Balance, int PinCode);