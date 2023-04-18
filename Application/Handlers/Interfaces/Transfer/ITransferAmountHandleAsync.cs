using FluentResults;
using PicPayLite.Domain.Tranfers;

namespace PicPayLite.Application.Handlers.Interfaces
{
    public interface ITransferAmountHandleAsync
    {
        Task<Result> TransferAsync(Transfer transfer);
    }
}