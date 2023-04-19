using FluentResults;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Application.Helpers;
using PicPayLite.Domain.Clients;
using PicPayLite.Domain.Errors;
using PicPayLite.Domain.Repositories;
using PicPayLite.Infrastructure;
using PicPayLite.Presentation.RequestsPattern;

namespace PicPayLite.Application.Handlers
{
    public class ClientCreateHandleAsync : IClientCreateHandleAsync
    {
        private IClientRepository _clientRepository;
        private ApplicationDbContext _dbContext;
        public ClientCreateHandleAsync(
            IClientRepository clientRepository, 
            ApplicationDbContext dbContext,
            IAccountCreateHandleAsync accountCreateHandle)
        {
            _clientRepository = clientRepository;
            _dbContext = dbContext;
        }

        public async Task<Result<Client>> CreateAsync(CreateClientRequest data)
        {
            Client client = Client.Create(data.Name, data.Email, data.Type, data.Document);
            
            // bool clientAlreadyExist = await ClientHelper.ValidateClientExist(client.Document.value);

            // if (clientAlreadyExist)
            //     return Result.Fail(DomainErrors.Clients.ClientAlreadyExist);

            // _clientRepository.Add(client);
            // await _dbContext.SaveChangesAsync();

            return Result.Ok(client);
        }
    }
}
