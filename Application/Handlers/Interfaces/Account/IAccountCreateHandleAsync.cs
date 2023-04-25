using FluentResults;
using PicPayLite.Domain.Accounts;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Application.Handlers.Interfaces
{
    public interface IAccountCreateHandleAsync
    {
        Task<Result> CreateAsync(CreateAccountRequest data);
    }
}