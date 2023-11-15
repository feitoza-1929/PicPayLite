
using FluentResults;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.Errors;
using PicPayLite.Domain.Repositories;
using PicPayLite.Domain.Tranfers;
using PicPayLite.Infrastructure;
using PicPayLite.Infrastructure.API;
using PicPayLite.Infrastructure.Cache;

namespace PicPayLite.Application.Handlers
{
    public class TransferAmountHandleAsync : ITransferAmountHandleAsync
    {
        private readonly CachedAccountRepository _accountRepository;
        private readonly ITransferRepository _transferRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly IAuthorizationTransfer _authorizationTransfer;

        public TransferAmountHandleAsync(
            CachedAccountRepository accountRepository,
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
            Account recipientAccount = await _accountRepository
                .GetAccountByNumber(transfer.Recipient.AccountNumber);

            Account senderAccount = await _accountRepository
                .GetAccountByNumber(transfer.Sender.AccountNumber);

            Result withdrawAmountResult = await WithdrawAmount(senderAccount, transfer.Amount);

            if (withdrawAmountResult.IsFailed)
                return Result.Fail(withdrawAmountResult.Errors.FirstOrDefault());

            Result depositAmountResult = DepositAmount(recipientAccount, transfer.Amount);

            if (depositAmountResult.IsFailed)
                return Result.Fail(depositAmountResult.Errors.FirstOrDefault());

            AuthTransfer authResponse = await _authorizationTransfer.GetAsync();

            if (authResponse.Message != "Success")
            {
                DepositAmount(senderAccount, transfer.Amount);
                await _dbContext.SaveChangesAsync();
                return Result.Fail(DomainErrors.Transfer.TransferNotAuthorize);
            }

            await _dbContext.SaveChangesAsync();

            return Result.Ok();
        }

        private async Task<Result> WithdrawAmount(Account account, float amount)
        {
            Result<float> resultWithdraw = account.Withdraw(amount);

            if (resultWithdraw.IsFailed)
                return Result.Fail(resultWithdraw.Errors.First());

            await _dbContext.SaveChangesAsync();

            return Result.Ok();
        }

        private Result DepositAmount(Account account, float amount)
        {
            Result<float> resultDeposit = account.Deposit(amount);

            if (resultDeposit.IsFailed)
                return Result.Fail(resultDeposit.Errors.FirstOrDefault());

            return Result.Ok();
        }
    }
}