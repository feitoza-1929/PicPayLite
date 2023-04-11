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

        public async static Task<bool> ValidateAccountExist(int accountNumber)
        {
            Account data = await _accountRepository.GetAccountByNumber(accountNumber);

            return data == null
            ? false
            : true;
        }
    }
}