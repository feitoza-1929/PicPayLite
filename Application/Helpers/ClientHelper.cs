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

        public static bool ValidateClientExist(string documentNumber)
        {
            if(documentNumber is null)
                throw new NullReferenceException($"the documentoNumber for validate client is null");
                
            Client data = _clientRepository.GetClientByDocument(documentNumber).First();

            return data == null
            ? false
            : true;       
        }
    }
}
