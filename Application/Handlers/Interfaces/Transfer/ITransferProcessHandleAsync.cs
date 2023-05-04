using FluentResults;
using PicPayLite.Domain.Tranfers;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Application.Handlers.Interfaces
{
    public interface ITransferProcessHandleAsync
    {
        Task<Result<Transfer>> ProcessAsync(TransferAmountRequest requestData);
    }
}