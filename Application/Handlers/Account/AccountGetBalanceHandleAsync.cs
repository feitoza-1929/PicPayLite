using FluentResults;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.Clients;
using PicPayLite.Domain.Errors;
using PicPayLite.Domain.Repositories;
using PicPayLite.Domain.ValueObjects;
using PicPayLite.Infrastructure;

namespace PicPayLite.Application.Handlers
{

    public class AccountGetBalanceHandleAsync : IAccountGetBalanceHandleAsync
    {
        private readonly object _dbContext;
        private readonly IAccountRepository _accountRepository;
        private readonly IClientRepository _clientRepository;

        public AccountGetBalanceHandleAsync(
            IAccountRepository accountRepository,
            IClientRepository clientRepository,
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _accountRepository = accountRepository;
            _clientRepository = clientRepository;
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