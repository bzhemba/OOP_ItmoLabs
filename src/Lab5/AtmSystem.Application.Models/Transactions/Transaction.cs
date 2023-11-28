using System;

namespace AtmSystem.Application.Models.Transactions;

public record Transaction(int TransactionId, TransactionType TransactionType, int TransactionAmount, DateTime TransactionTime);