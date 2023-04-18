using FluentResults;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Application.Handlers.Interfaces
{
    public interface ITransferProcessHandleAsync
    {
        Task<Result> ProcessAsync(TransferAmountRequest requestData);
    }
}