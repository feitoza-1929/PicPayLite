using PicPayLite.Domain.Clients;

namespace PicPayLite.Domain.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetClientById(Guid id);
        Task<Client> GetClientByDocument(string documentValue);
        Task<List<Client>> GetAllClients();
        Task<bool> AnyDocumentValue(string documentValue);
    }
}
