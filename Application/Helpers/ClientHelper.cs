using PicPayLite.Domain.Clients;
using PicPayLite.Domain.Repositories;

namespace PicPayLite.Application.Helpers
{
    public class ClientHelper
    {
        private static IClientRepository _clientRepository;

        public ClientHelper(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async static Task<bool> ValidateClientExist(string documentNumber)
        {
            if(documentNumber is null)
                throw new NullReferenceException($"the documentoNumber for validate client is null");
                
            Client data = await _clientRepository.GetClientByDocument(documentNumber);

            return data == null
            ? false
            : true;       
        }
    }
}
