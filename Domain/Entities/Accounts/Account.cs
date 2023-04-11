using FluentResults;
using PicPayLite.Domain.Errors;

namespace PicPayLite.Domain.Accounts
{
    public class Account
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public int Number { get; private set; }
        public Balance Balance { get; private set;}

        private Account(Guid clientId, int number, Balance balance)
        {
            Id = new Guid();
            ClientId = clientId;
            Number = number;
            Balance = balance;
        }

        public static Account Create(Guid clientId, int number, Balance balance)
        {
            return new Account(clientId, number, balance);
        }

        public Result<float> Withdraw(float value)
        {
            if (value <= 0)
                return Result.Fail(DomainErrors.Accounts.InvalidAmountValue);

            if(value > Balance.Amount || Balance.Amount == 0)
                return Result.Fail(DomainErrors.Accounts.InsuficientBalance);

            Balance.Amount = Balance.Amount - value;

            return Result.Ok(value);
        }
        public Result Deposit(float value)
        {
            if(value <= 0)
                return Result.Fail(DomainErrors.Accounts.InvalidAmountValue);

            Balance.Amount = Balance.Amount + value;
            return Result.Ok();
        }
    }
}