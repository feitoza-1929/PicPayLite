using FluentResults;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.Clients;
using PicPayLite.Domain.Repositories;
using PicPayLite.Infrastructure;

namespace PicPayLite.Application.Handlers
{

    public class AccountGetHandleAsync : IAccountGetHandleAsync
    {
        private readonly object _dbContext;
        private readonly IAccountRepository _accountRepository;
        private readonly IClientRepository _clientRepository;

        public AccountGetHandleAsync(
            IAccountRepository accountRepository,
            IClientRepository clientRepository,
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _accountRepository = accountRepository;
            _clientRepository = clientRepository;
        }

        public async Task<Result<Account>> GetAsync(string clientDocument)
        {
            Client client =
                await _clientRepository
                .GetClientByDocument(clientDocument);

            Account account =
                await _accountRepository
                .GetAccountByClientId(client.Id);

            return Result.Ok(account);
        }
    }
}