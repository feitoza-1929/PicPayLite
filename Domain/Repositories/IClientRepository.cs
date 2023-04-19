using PicPayLite.Domain.Clients;

namespace PicPayLite.Domain.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        List<Client> GetClientById(Guid id);
        List<Client> GetClientByDocument(string documentNumber);
    }
}
