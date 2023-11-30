namespace AtmSystem.Application.Models.Transactions;

public record Transaction(int TransactionId, long AccountId, TransactionType TransactionType, DateTime TransactionTime);