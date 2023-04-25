using PicPayLite.Domain.Repositories;

namespace PicPayLite.Application.Handlers
{
    public class ClientTokenHandleAsync
    {
        private readonly IClientRepository _clientRepository;
        public ClientTokenHandleAsync(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        
        public async Task<Result<Client>> CreateAsync()
        {
            // 1) GET THE CLIENT AND VERIFY IF EXIST
            return await _clientRepository.GetClientByDocument("00000000000");
            
            // 2) THEN GENERATE THE TOKEN

            // 3) AND RETURN THE TOKEN
        }
    }
}
