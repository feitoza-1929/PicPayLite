using FluentResults;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Domain.Clients;
using PicPayLite.Domain.Errors;
using PicPayLite.Domain.Repositories;
using PicPayLite.Infrastructure.Authentication;

namespace PicPayLite.Application.Handlers
{
    public class ClientTokenHandleAsync : IClientTokenHandleAsync
    {
        private readonly IClientRepository _clientRepository;
        private readonly IJwtProvider _jwtProvider;
        public ClientTokenHandleAsync(IClientRepository clientRepository, IJwtProvider jwtProvider)
        {
            _clientRepository = clientRepository;
            _jwtProvider = jwtProvider;
        }

        
        public async Task<Result<string>> CreateAsync(string documentValue)
        {
            Client client = await _clientRepository.GetClientByDocument(documentValue);

            if(client is null)
                return Result.Fail(DomainErrors.Clients.ClientNotFound);

            string token = _jwtProvider.Generate(client);
            
            return Result.Ok(token);
        }
    }
}
