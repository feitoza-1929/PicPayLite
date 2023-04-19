using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.Repositories;

namespace PicPayLite.Application.Helpers
{
    public class AccountHelper
    {
        private static IAccountRepository _accountRepository;

        public AccountHelper(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public static bool ValidateAccountExist(int accountNumber)
        {
            Account data = _accountRepository.GetAccountByNumber(accountNumber).First();

            return data == null
            ? false
            : true;
        }
    }
}