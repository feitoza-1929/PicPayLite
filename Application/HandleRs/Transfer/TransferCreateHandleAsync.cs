using FluentResults;
using PicPayLite.Application.Helpers;
using PicPayLite.Domain.Clients;
using PicPayLite.Domain.Errors;
using PicPayLite.Domain.Repositories;
using PicPayLite.Domain.Tranfers;
using PicPayLite.Infrastructure;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Application.Handlers
{
    public class TransferCreateHandleAsync : ITransferCreateHandleAsync
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransferRepository _transferRepository;
        private readonly ApplicationDbContext _dbContext;

        public TransferCreateHandleAsync(
            IAccountRepository accountRepository,
            ITransferRepository transferRepository,
            ApplicationDbContext dbContext)
        {
            _accountRepository = accountRepository;
            _transferRepository = transferRepository;
            _dbContext = dbContext;
        }

        public async Task<Result<Transfer>> CreateAsync(TransferAmountRequest data)
        {
            bool recipientAccountExist = await AccountHelper.ValidateAccountExist(data.Recipient.AccountNumber);
            bool senderAccountExist = await AccountHelper.ValidateAccountExist(data.Recipient.AccountNumber);

            if(recipientAccountExist is false && senderAccountExist is false)
                return Result.Fail(DomainErrors.Accounts.AccountNotFound);

            Transfer transfer = Transfer.Create(data.Amount, data.Sender, data.Recipient);

            _transferRepository.Add(transfer);
            await _dbContext.SaveChangesAsync();

            return Result.Ok(transfer);
        }
    }
}