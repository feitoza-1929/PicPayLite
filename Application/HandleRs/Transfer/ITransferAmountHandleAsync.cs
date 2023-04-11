using FluentResults;
using PicPayLite.Domain.Tranfers;

namespace PicPayLite.Application.Handlers
{
    public interface ITransferAmountHandleAsync
    {
        Task<Result> TransferAsync(Transfer transfer);
    }
}