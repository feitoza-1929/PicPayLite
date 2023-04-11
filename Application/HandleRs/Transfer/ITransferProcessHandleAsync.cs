using FluentResults;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Application.Handlers
{
    public interface ITransferProcessHandleAsync
    {
        Task<Result> ProcessAsync(TransferAmountRequest requestData);
    }
}