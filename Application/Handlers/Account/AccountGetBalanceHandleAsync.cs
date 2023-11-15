using FluentResults;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.Errors;
using PicPayLite.Domain.ValueObjects;
using PicPayLite.Infrastructure.Cache;

namespace PicPayLite.Application.Handlers
{

    public class AccountGetBalanceHandleAsync : IAccountGetBalanceHandleAsync
    {
        private readonly CachedAccountRepository _accountRepository;

        public AccountGetBalanceHandleAsync(
            CachedAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;  
        }

        public async Task<Result<Balance>> GetAsync(int accountNumber)
        {
            if(accountNumber < 1000 || accountNumber > 9999)
                return Result.Fail(DomainErrors.Account.InvalidAccountNumber);
                
            Account account = 
                await _accountRepository.GetAccountByNumber(accountNumber);
            
            if(account is null)
                return Result.Fail(DomainErrors.Account.AccountNotFound);

            return Result.Ok(account.Balance);
        }
    }
}