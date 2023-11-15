using FluentResults;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Domain.Errors;
using PicPayLite.Domain.Repositories;
using PicPayLite.Domain.Tranfers;
using PicPayLite.Infrastructure;
using PicPayLite.Infrastructure.Cache;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Application.Handlers
{
    public class TransferCreateHandleAsync : ITransferCreateHandleAsync
    {
        private readonly CachedAccountRepository _accountRepository;
        private readonly ITransferRepository _transferRepository;
        private readonly ApplicationDbContext _dbContext;

        public TransferCreateHandleAsync(
            CachedAccountRepository accountRepository,
            ITransferRepository transferRepository,
            ApplicationDbContext dbContext)
        {
            _accountRepository = accountRepository;
            _transferRepository = transferRepository;
            _dbContext = dbContext;
        }

        public async Task<Result<Transfer>> CreateAsync(TransferAmountRequest data)
        {
            bool recipientAccountExist = await _accountRepository.AnyAccountNumber(data.Recipient.AccountNumber);
            bool senderAccountExist = await _accountRepository.AnyAccountNumber(data.Sender.AccountNumber);

            if(recipientAccountExist is false && senderAccountExist is false)
                return Result.Fail(DomainErrors.Account.AccountNotFound);

            Transfer transfer = Transfer.Create(data.Amount, data.Sender, data.Recipient);

            //TODO: Avaliate if there's need to save these entities in the database 
            //_transferRepository.Add(transfer);
            //await _dbContext.SaveChangesAsync();

            return Result.Ok(transfer);
        }
    }
}