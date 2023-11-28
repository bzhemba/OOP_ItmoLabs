using AtmSystem.Application.Models.Users;

namespace AtmSystem.Application.Models.BankAccounts;

public record BankAccount(long Id, User Owner, int Balance, int PinCode);