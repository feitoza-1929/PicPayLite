using FluentResults;

namespace PicPayLite.Domain.Errors
{
    public class DomainErrors : Error
    {
        public DomainErrors(string errorCode, string errorMessage)
        : base(errorMessage)
        {
            WithMetadata("Code", errorCode);
        }

        public static class Account
        {
            public static readonly DomainErrors AccountNotFound = new("AccountNotFound", "account can't be found");
            public static readonly DomainErrors AccountAlreadyExist = new("AccountAlreadyExist", "the given account already exist");
            public static readonly DomainErrors InsuficientBalance = new("InsuficientBalance", "there's no sufficient balance");
            public static readonly DomainErrors InvalidAmountValue = new("InvalidAmountValue", "amount value must be a valid positive number");
            public static readonly DomainErrors InvalidAccountNumber = new("InvalidAccountNumber", "account number must be a 4 digits integer");

        }

        public static class Client
        {
            public static readonly DomainErrors ClientNotFound = new("ClientNotFound", "client can't be found");
            public static readonly DomainErrors ClientAlreadyExist = new("ClientAlreadyExist", "the given client already exist");
            public static readonly DomainErrors InvalidEmail = new("InvalidEmail", "the given email is invalid");
            public static readonly DomainErrors InvalidName = new("InvalidEmail", "the given name is invalid");
            public static readonly DomainErrors InvalidDocument = new("InvalidDocument", "the given document is invalid");

        }

        public static class Transfer
        {
            public static readonly DomainErrors InsuficientBalance = new("InsuficientBalance", "there's no sufficient balance to complete the transfer");
            public static readonly DomainErrors TransferNotAuthorize = new("TransferNotAuthorize", "transfer can't be completed because is not authorize");

        }
    }
}