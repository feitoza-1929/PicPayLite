using FluentResults;
using PicPayLite.Domain.Tranfers;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Application.Handlers
{
    public interface ITransferCreateHandleAsync
    {
        Task<Result<Transfer>> CreateAsync(TransferAmountRequest data);
    }
}