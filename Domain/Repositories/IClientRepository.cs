using PicPayLite.Domain.Clients;

namespace PicPayLite.Domain.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetClientById(Guid id);
        Task<Client> GetClientByDocument(string documentNumber);
    }
}
