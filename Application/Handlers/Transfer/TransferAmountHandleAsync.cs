using FluentResults;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Application.Helpers;
using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.Clients;
using PicPayLite.Domain.Errors;
using PicPayLite.Domain.Repositories;
using PicPayLite.Domain.Tranfers;
using PicPayLite.Infrastructure;
using PicPayLite.Infrastructure.API;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Application.Handlers
{
    public class TransferAmountHandleAsync : ITransferAmountHandleAsync
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransferRepository _transferRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly IAuthorizationTransfer _authorizationTransfer;

        public TransferAmountHandleAsync(
            IAccountRepository accountRepository,
            ITransferRepository transferRepository,
            ApplicationDbContext dbContext,
            IAuthorizationTransfer authorizationTransfer)
        {
            _accountRepository = accountRepository;
            _transferRepository = transferRepository;
            _dbContext = dbContext;
            _authorizationTransfer = authorizationTransfer;
        }

        public async Task<Result> TransferAsync(Transfer transfer)
        {
            Account recipientAccount = await _accountRepository.GetAccountByNumber(transfer.Recipient.AccountNumber);
            Account senderAccount = await _accountRepository.GetAccountByNumber(transfer.Sender.AccountNumber);

            Result<float> resultWithdraw = senderAccount.Withdraw(transfer.Amount);

            if (resultWithdraw.IsFailed)
                return Result.Fail(resultWithdraw.Errors.First());

            Result<float> resultDeposit = recipientAccount.Deposit(transfer.Amount);

            if (resultDeposit.IsFailed)
                return Result.Fail(resultWithdraw.Errors.First());

            AuthData authorizationTransfer = await _authorizationTransfer.GetAsync();

            if (authorizationTransfer.Message != "Success")
                return Result.Fail(DomainErrors.Transfers.TransferNotAuthorize);

            await _dbContext.SaveChangesAsync();

            return Result.Ok();
        }
    }
}