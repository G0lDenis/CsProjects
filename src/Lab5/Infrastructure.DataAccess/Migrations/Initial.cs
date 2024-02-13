using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type user_role as enum
        (
            'admin',
            'client'
        );

        create type operation_result_state as enum
        (
            'success',
            'fail'
        );

        create type operation_types as enum
        (
            'deposit',
            'withdraw'
        );

        create table users
        (
            user_id bigint primary key generated always as identity,
            user_name text not null ,
            user_role user_role not null
        );

        create table bank_accounts
        (
            bank_account_id bigint primary key generated always as identity,
            user_id bigint not null references users(user_id),
            bank_account_code bigint not null generated always as identity,
            pin_code bigint not null,
            amount bigint not null
        );
        
        create table operation_history
        (
            operation_id bigint primary key generated always as identity,
            bank_account_id bigint not null references bank_accounts(bank_account_id),
            amount bigint not null,
            result_state operation_result_state not null
        )
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table operation_history;
        drop table bank_accounts;
        drop table users;

        drop type user_role;
        drop type operation_result_states;
        drop type operation_types;
        """;
}