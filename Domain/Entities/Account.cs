using FluentResults;
using PicPayLite.Domain.Clients;
using PicPayLite.Domain.Errors;
using PicPayLite.Domain.ValueObjects;

namespace PicPayLite.Domain.Accounts
{
    public class Account
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public int Number { get; private set; }
        public Balance Balance { get; private set;}
        public Client Client { get; private set; }

        private Account(Guid clientId, int number, Balance balance) 
        : this(clientId, number)
        {
            Balance = balance;
        }

        private Account(Guid clientId, int number)
        {
            ClientId = clientId;
            Number = number;
        }

        public static Account Create(Guid clientId, int number, Balance balance)
        {
            return new Account(clientId, number, balance);
        }

        public Result<float> Withdraw(float value)
        {
            if (value <= 0)
                return Result.Fail(DomainErrors.Account.InvalidAmountValue);

            if(value > Balance.Amount || Balance.Amount == 0)
                return Result.Fail(DomainErrors.Account.InsuficientBalance);

            Balance.Amount = Balance.Amount - value;

            return Result.Ok(value);
        }
        public Result Deposit(float value)
        {
            if(value <= 0)
                return Result.Fail(DomainErrors.Account.InvalidAmountValue);

            Balance.Amount = Balance.Amount + value;
            return Result.Ok();
        }
    }
}