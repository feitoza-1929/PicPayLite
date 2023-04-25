using FluentResults;
using PicPayLite.Domain.Clients;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Application.Handlers.Interfaces
{
    public interface IClientCreateHandleAsync
    {
        Task<Result> CreateAsync(CreateClientRequest data);
    }
}