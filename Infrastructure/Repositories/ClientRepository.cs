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
            List<Client> data = await _dbContext.Clients
                .Where(client => client.Id.Equals(id))
                .ToListAsync();

            return data.FirstOrDefault();
        }

        public async Task<List<Client>> GetAllClients()
        {
            List<Client> data = await _dbContext.Clients.ToListAsync();

            return data;
        }

        public async Task<bool> AnyDocumentValue(string documentValue)
        {
            return await _dbContext.Clients.AnyAsync(c => c.DocumentValue == documentValue);
        }
    }
}