using FluentResults;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Application.Helpers;
using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.Errors;
using PicPayLite.Domain.Repositories;
using PicPayLite.Domain.ValueObjects;
using PicPayLite.Infrastructure;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Application.Handlers
{
    public class AccountCreateHandleAsync : IAccountCreateHandleAsync
    {
        private readonly float defaultAmount = 500;
        private readonly string defaultCurrency = "BRL";
        private readonly IAccountRepository _accountRepository;
        private readonly ApplicationDbContext _dbContext;

        public AccountCreateHandleAsync(IAccountRepository accountRepository, ApplicationDbContext dbContext)
        {
            _accountRepository = accountRepository;
            _dbContext = dbContext;
        }

        public async Task<Result<Account>> CreateAsync(CreateAccountRequest data)
        {
            bool clientExist = ClientHelper.ValidateClientExist(data.Document.value);
            if(clientExist is false)
                return Result.Fail(DomainErrors.Clients.ClientNotFound);

            int accountNumber = new Random().Next(1000, 9999);
            Balance balance = new Balance(defaultCurrency, defaultAmount);
            Account account = Account.Create(data.ClientId, accountNumber, balance);

            _accountRepository.Add(account);
            await _dbContext.SaveChangesAsync();

            return Result.Ok(account);
        }
    }
}