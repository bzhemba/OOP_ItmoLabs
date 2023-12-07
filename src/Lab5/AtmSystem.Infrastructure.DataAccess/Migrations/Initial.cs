using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace AtmSystem.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create type transaction_type as enum
    (
        'withdrawal',
        'deposit'
    );
    
    create table bankUsers
    (
    account_id bigint primary key generated always as identity,
    account_name text not null
    );
    
    create table accounts
    (
        account_id bigint primary key generated always as identity ,
        account_owner bigint not null references bankUsers(account_id),
        account_balance int not null,
        account_pin int not null
    );

    create table TransactionHistory
    (
        transaction_id bigint primary key generated always as identity,
        account_id bigint not null references accounts(account_id),
        transaction_type transaction_type not null,
        transaction_amount int not null,
        transaction_date date not null
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table users;
    drop table accounts;
    drop table transactions;

    drop type transaction_type;
    """;
}