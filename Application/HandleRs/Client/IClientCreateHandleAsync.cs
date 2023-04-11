using FluentResults;
using PicPayLite.Domain.Clients;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Application.Handlers
{
    public interface IClientCreateHandleAsync
    {
        Task<Result<Client>> CreateAsync(CreateClientRequest data);
    }
}