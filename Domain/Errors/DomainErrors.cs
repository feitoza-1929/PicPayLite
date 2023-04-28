using FluentResults;

namespace PicPayLite.Domain.Errors
{
    public static class DomainErrors
    {
        public static class Accounts
        {
            public static readonly Error AccountNotFound = new("AccountNotFound");
            public static readonly Error AccountAlreadyExist = new("AccountAlreadyExist");
            public static readonly Error InsuficientBalance = new("InsuficientBalance");
            public static readonly Error InvalidAmountValue = new("InvalidAmountValue");

        }

        public static class Clients
        {
            public static readonly Error ClientNotFound = new("ClientNotFound");
            public static readonly Error ClientAlreadyExist = new("ClientAlreadyExist");
        }

        public static class Transfers
        {
            public static readonly Error InsuficientBalance = new("InsuficientBalance");
            public static readonly Error TransferNotAuthorize = new("TransferNotAuthorize");

        }
    }
}