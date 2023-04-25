using FluentResults;
using PicPayLite.Domain.Clients;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Application.Handlers.Interfaces
{
    public interface IClientTokenHandleAsync
    {
        Task<Result<String>> CreateAsync(string documentValue);
    }
}