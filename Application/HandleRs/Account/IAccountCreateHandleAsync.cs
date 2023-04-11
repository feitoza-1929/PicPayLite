using FluentResults;
using PicPayLite.Domain.Accounts;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Application.Handlers
{
    public interface IAccountCreateHandleAsync
    {
        Task<Result<Account>> CreateAsync(CreateAccountRequest data);
    }
}