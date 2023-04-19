using Microsoft.EntityFrameworkCore;
using PicPayLite.Domain.Clients;
using PicPayLite.Domain.Repositories;

namespace PicPayLite.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private ApplicationDbContext _dbContext;
        public ClientRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Client data)
        {
            _dbContext.Clients.Add(data);
        }

        public void Delete(Client data)
        {
            _dbContext.Clients.Remove(data);
        }

        public List<Client> GetClientById(Guid id)
        {
            List<Client> data = _dbContext.Clients
                .Where(client => client.Id == id)
                .Select(client => client)
                .ToList();

            if (data is null)
                throw new NullReferenceException("try to fetch client data by id, but is null");

            return data;
        }

        public List<Client> GetClientByDocument(string documentNumber)
        {
            List<Client> data = _dbContext.Clients
                .Where(client => client.Document.value == documentNumber)
                .Select(client => client)
                .ToList();

            if(data is null)
                throw new NullReferenceException("try to fetch client data by document, but is null");

            return data;
        }
    }
}