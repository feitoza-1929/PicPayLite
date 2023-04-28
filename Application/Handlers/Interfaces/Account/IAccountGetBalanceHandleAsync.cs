using FluentResults;
using PicPayLite.Domain.ValueObjects;

namespace PicPayLite.Application.Handlers.Interfaces
{
    public interface IAccountGetBalanceHandleAsync
    {
        Task<Result<Balance>> GetAsync(int accountNumber);
    }
}