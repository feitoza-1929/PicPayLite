using FluentResults;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Domain.Tranfers;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Application.Handlers
{
    public class TransferProcessHandleAsync : ITransferProcessHandleAsync
    {
        private readonly ITransferCreateHandleAsync _transferCreateHandleAsync;
        private readonly ITransferAmountHandleAsync _transferAmountHandleAsync;

        public TransferProcessHandleAsync(
            ITransferCreateHandleAsync transferCreateHandleAsync,
            ITransferAmountHandleAsync transferAmountHandleAsync)
        {
            _transferCreateHandleAsync = transferCreateHandleAsync;
            _transferAmountHandleAsync = transferAmountHandleAsync;
        }
        public async Task<Result<Transfer>> ProcessAsync(TransferAmountRequest requestData)
        {
            Result<Transfer> createResult = await _transferCreateHandleAsync.CreateAsync(requestData);

            if (createResult.IsFailed)
                return Result.Fail(createResult.Errors.FirstOrDefault());

            Result transferAmountResult = await _transferAmountHandleAsync.TransferAsync(createResult.Value);

            if (transferAmountResult.IsFailed)
                return Result.Fail(transferAmountResult.Errors.FirstOrDefault());

            return Result.Ok(createResult.Value);
        }
    }
}