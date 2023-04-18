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

        public async Task<Client> GetClientById(Guid id)
        {
            IEnumerable<Client> data = await _dbContext.Clients
                .Where(client => client.Id == id)
                .Select(client => client)
                .ToListAsync();

            return data.FirstOrDefault();
        }

        public async Task<Client> GetClientByDocument(string documentNumber)
        {
            IEnumerable<Client> data = await _dbContext.Clients
            .Where(client => client.Document.value == documentNumber)
            .ToListAsync();

            if(data is null)
                throw new NullReferenceException("try to fetch client data by document, but is null");

            return data.First();
        }
    }
}