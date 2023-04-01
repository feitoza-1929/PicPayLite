namespace PicPayLite.Domain.Errors
{
    public static class DomainErrors
    {
        public static class Accounts
        {
            public static readonly Error AccountNotFound = new("AccountNotFound", "account couldn't be found");
        }

        public static class Clients
        {
            public static readonly Error ClientNotFound = new("ClientNotFound", "client couldn't be found");
        }

        public static class Transfers
        {
            public static readonly Error InsuficientBalance = new("InsuficientBalance", "not enough balance");
        }
    }
}