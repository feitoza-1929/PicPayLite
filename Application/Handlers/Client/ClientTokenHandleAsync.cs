using FluentResults;
using PicPayLite.Application.Handlers.Interfaces;
using PicPayLite.Domain.Clients;
using PicPayLite.Domain.Repositories;

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
            // 1) GET THE CLIENT AND VERIFY IF EXIST
            Client client = await _clientRepository.GetClientByDocument(documentValue);
            
            // 2) THEN GENERATE THE TOKEN
            string token = await _jwtProvider.GenerateTokenAsync(client);

            // 3) AND RETURN THE TOKEN
            return token;
        }
    }
}
