using FluentResults;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.Clients;
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
        private readonly IClientRepository _clientRepository;
        private readonly ApplicationDbContext _dbContext;


        public AccountCreateHandleAsync(IAccountRepository accountRepository, IClientRepository clientRepository, ApplicationDbContext dbContext)
        {
            _accountRepository = accountRepository;
            _dbContext = dbContext;
            _clientRepository = clientRepository;
        }

        public async Task<Result<Account>> CreateAsync(CreateAccountRequest data)
        {
            bool clientExist = 
                await _clientRepository.AnyDocumentValue(data.Document.value);
            
            if (clientExist is false)
                return Result.Fail(DomainErrors.Client.ClientNotFound);

            Client client = 
                await _clientRepository.GetClientByDocument(data.Document.value);

            bool accountExist = 
                await _accountRepository.AnyAccountByClientId(client.Id);

            if(accountExist)
                return Result.Fail(DomainErrors.Account.AccountAlreadyExist);

            int accountNumber = new Random().Next(1000, 9999);
            Balance balance = new Balance(defaultCurrency, defaultAmount);
            Account account = Account.Create(client.Id, accountNumber, balance);

            _accountRepository.Add(account);
            await _dbContext.SaveChangesAsync();

            return Result.Ok();
        }
    }
}