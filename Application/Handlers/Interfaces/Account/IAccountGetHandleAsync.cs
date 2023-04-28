using FluentResults;
using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.ValueObjects;

namespace PicPayLite.Application.Handlers.Interfaces
{
    public interface IAccountGetHandleAsync
    {
        Task<Result<Account>> GetAsync(string clientDocument);
    }
}