using PicPayLite.Domain.Accounts;

namespace PicPayLite.Presentation.ResponsePattern
{
    public class AccountResponse
    {
        public int Number { get; private set; }

        private AccountResponse(int number)
        {
            Number = number;
        }

        public static AccountResponse Create(Account account)
        {
            return new AccountResponse(account.Number);
        }
    }
}